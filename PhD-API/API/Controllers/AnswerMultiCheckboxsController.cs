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
using API.DTO.AnswerMultiCheckbox;
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
    public class AnswerMultiCheckboxsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerRepository _answerRepository;
        private readonly IAnswerMultiCheckboxRepository _answerMultiCheckboxRepository;
        private readonly IResearchQuestionRepository _researchQuestionRepository;
        private readonly IResearchRepository _researchRepository;

        public AnswerMultiCheckboxsController(IMapper mapper, IUnitOfWork unitOfWork, IAnswerMultiCheckboxRepository answerMultiCheckboxRepository, IResearchQuestionRepository researchQuestionRepository, IResearchRepository researchRepository, IAnswerRepository answerRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _answerMultiCheckboxRepository = answerMultiCheckboxRepository;
            _researchQuestionRepository = researchQuestionRepository;
            _researchRepository = researchRepository;
            _answerRepository = answerRepository;
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<AnswerMultiCheckboxForGetDTO>>> Get(int? id)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string role = claimsIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).FirstOrDefault()?.Value;

            if (role == RoleEnum.Admin.ToString())
            {
                List<AnswerMultiCheckboxForGetDTO> answers = _mapper.Map<List<AnswerMultiCheckboxForGetDTO>>(await _answerMultiCheckboxRepository.GetByResearchAsync(Convert.ToInt32(id)).ConfigureAwait(true));
                return Ok(answers);
            }
            else
            {
                string researchId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;
                List<AnswerMultiCheckboxForGetDTO> answers = _mapper.Map<List<AnswerMultiCheckboxForGetDTO>>(await _answerMultiCheckboxRepository.GetByResearchAsync(Convert.ToInt32(researchId)).ConfigureAwait(true));
                return Ok(answers);
            }


        }

        [HttpPut]
        [Authorize(Roles = "Researcher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AnswerMultiCheckboxForGetDTO>> Put(AnswerMultiCheckboxForEditDTO[] list)
        {
            foreach (var model in list)
            {
                AnswerMultiCheckbox answerMultiCheckbox = _mapper.Map<AnswerMultiCheckbox>(model);
                answerMultiCheckbox.Radio = Convert.ToBoolean(list[0].Radio);
                AnswerMultiCheckbox oldAnswerMultiCheckbox = await _answerMultiCheckboxRepository.GetAsync(model.Id).ConfigureAwait(true);
                answerMultiCheckbox.ResearchId = oldAnswerMultiCheckbox.ResearchId;
                _answerMultiCheckboxRepository.Edit(answerMultiCheckbox);
            }

            var claimsIdentity = User.Identity as ClaimsIdentity;
            string researchId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;

            var researchQuestion = await _researchQuestionRepository.GetAsync(Convert.ToInt32(researchId), list[0].QuestionId);

            var research = await _researchRepository.GetAsync(Convert.ToInt32(researchId));

            if (Convert.ToBoolean(list[0].Radio) == false && researchQuestion.Answered == false)
            {
                researchQuestion.Answered = true;
                _researchQuestionRepository.Edit(researchQuestion);

                research.AnswersCount++;
                _researchRepository.Edit(research);
            }
            else if (Convert.ToBoolean(list[0].Radio) == true && (list.Any(d => d.Checked1) || list.Any(d => d.Checked2)) && researchQuestion.Answered == false)
            {
                researchQuestion.Answered = true;
                _researchQuestionRepository.Edit(researchQuestion);

                research.AnswersCount++;
                _researchRepository.Edit(research);
            }
            else if (Convert.ToBoolean(list[0].Radio) == true && list.All(d => d.Checked1 == false) && list.All(d => d.Checked2 == false) && researchQuestion.Answered == true)
            {
                researchQuestion.Answered = false;
                _researchQuestionRepository.Edit(researchQuestion);

                research.AnswersCount--;
                _researchRepository.Edit(research);
            }


            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            return Ok(research.AnswersCount);
        }



        [HttpPut("init")]
        [AllowAnonymous]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AnswerMultiCheckboxForGetDTO>> Init([FromForm] FileDTO model)
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

            var answers = await _answerRepository.GetAsync(QuestionTypeNum.MultiAmount).ConfigureAwait(true);
            var multiCheckboxs = await _answerMultiCheckboxRepository.GetAsync().ConfigureAwait(true);

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
                                var answerMultiCheckbox = multiCheckboxs.FirstOrDefault(d => d.ResearchId == research.Id && d.AnswerId == Convert.ToInt32(textSplit[1]));
                                if (answerMultiCheckbox != null)
                                {
                                    answerMultiCheckbox.Checked1 = Convert.ToBoolean(workSheet.Cells[i, col].Value);
                                    answerMultiCheckbox.Checked2 = Convert.ToBoolean(workSheet.Cells[i, col + 1].Value);

                                    if (answerMultiCheckbox.Checked1 || answerMultiCheckbox.Checked2)
                                        answerMultiCheckbox.Radio = true;

                                    _answerMultiCheckboxRepository.Edit(answerMultiCheckbox);
                                }
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    throw new Exception($"row {i}");
                }
            }

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);
            return Ok();
        }
    }
}