using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Core.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Core.UnitOfWork;
using System.Security.Claims;
using System.Linq;
using System;
using API.DTO.AnswerMultiAmount;
using Domain.Entities;
using Domain.Enums;
using API.DTO;
using Utilities.StaticHelpers;
using System.IO;
using OfficeOpenXml;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerMultiAmountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerRepository _answerRepository;
        private readonly IAnswerMultiAmountRepository _answerMultiAmountRepository;
        private readonly IResearchQuestionRepository _researchQuestionRepository;
        private readonly IResearchRepository _researchRepository;

        public AnswerMultiAmountsController(IMapper mapper, IUnitOfWork unitOfWork, IAnswerMultiAmountRepository answerMultiAmountRepository, IResearchQuestionRepository researchQuestionRepository, IResearchRepository researchRepository, IAnswerRepository answerRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _answerMultiAmountRepository = answerMultiAmountRepository;
            _researchQuestionRepository = researchQuestionRepository;
            _researchRepository = researchRepository;
            _answerRepository = answerRepository;
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<AnswerMultiAmountForGetDTO>>> Get(int? id)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string role = claimsIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).FirstOrDefault()?.Value;

            if (role == RoleEnum.Admin.ToString())
            {
                List<AnswerMultiAmountForGetDTO> answers = _mapper.Map<List<AnswerMultiAmountForGetDTO>>(await _answerMultiAmountRepository.GetByResearchAsync(Convert.ToInt32(id)).ConfigureAwait(true));
                return Ok(answers);
            }
            else
            {
                string researchId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;
                List<AnswerMultiAmountForGetDTO> answers = _mapper.Map<List<AnswerMultiAmountForGetDTO>>(await _answerMultiAmountRepository.GetByResearchAsync(Convert.ToInt32(researchId)).ConfigureAwait(true));
                return Ok(answers);
            }
        }


        [HttpPut]
        [Authorize(Roles = "Researcher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AnswerMultiAmountForGetDTO>> Put(AnswerMultiAmountForEditDTO[] list)
        {
            foreach (var model in list)
            {
                AnswerMultiAmount answerMultiAmount = _mapper.Map<AnswerMultiAmount>(model);
                AnswerMultiAmount oldAnswerMultiAmount = await _answerMultiAmountRepository.GetAsync(model.Id).ConfigureAwait(true);
                answerMultiAmount.ResearchId = oldAnswerMultiAmount.ResearchId;
                _answerMultiAmountRepository.Edit(answerMultiAmount);
            }



            var claimsIdentity = User.Identity as ClaimsIdentity;
            string researchId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;

            var researchQuestion = await _researchQuestionRepository.GetAsync(Convert.ToInt32(researchId), list[0].QuestionId);
            var research = await _researchRepository.GetAsync(Convert.ToInt32(researchId));

            if (list.All(d => d.Amount == null) && researchQuestion.Answered == true)
            {
                researchQuestion.Answered = false;
                _researchQuestionRepository.Edit(researchQuestion);

                research.AnswersCount--;
                _researchRepository.Edit(research);
            }
            else if (list.Any(d => d.Amount != null) && researchQuestion.Answered == false)
            {
                researchQuestion.Answered = true;
                _researchQuestionRepository.Edit(researchQuestion);

                research.AnswersCount++;
                _researchRepository.Edit(research);
            }

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);


            return Ok(research.AnswersCount);
        }


        [HttpPut("init")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AnswerMultiAmountForGetDTO>> Init([FromForm] FileDTO model)
        {

            var researchs = await _researchRepository.GetAsync().ConfigureAwait(true);

            FileOperations.WriteFile($"uploadFiles", model.File);
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"Content/uploadFiles", model.File.FileName);
            FileInfo file = new FileInfo(path);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using ExcelPackage package = new ExcelPackage(file);
            ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
            int totalRows = workSheet.Dimension.Rows;
            int colCount = workSheet.Dimension.End.Column;  //get Column Count

            var multiAmounts = await _answerMultiAmountRepository.GetAsync().ConfigureAwait(true);

            for (int i = 5; i <= totalRows; i++)
            {
                try
                {
                    Research research = researchs.FirstOrDefault(f => f.Code == Convert.ToInt32(workSheet.Cells[i, 1].Value));
                    for (int col = 1; col <= colCount; col++)
                    {
                        var cell = workSheet.Cells[4, col].Value;
                        if (cell != null)
                        {
                            string[] textSplit = cell.ToString().Trim().Split("-");
                            if (textSplit.Length > 1)
                            {
                                var answerMultiAmount = multiAmounts.FirstOrDefault(d => d.ResearchId == research.Id && d.AnswerId == Convert.ToInt32(textSplit[1]));
                                if (answerMultiAmount != null)
                                {
                                    answerMultiAmount.Amount = Convert.ToDecimal(workSheet.Cells[i, col].Value);

                                    _answerMultiAmountRepository.Edit(answerMultiAmount);
                                }
                            }
                        }

                    }
                }
                catch (Exception)
                {
                    throw new Exception($"row {i}");
                }
            }

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok();
        }

    }
}