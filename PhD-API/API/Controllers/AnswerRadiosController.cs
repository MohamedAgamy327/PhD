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
using API.DTO.AnswerRadio;
using API.Errors;
using Utilities.StaticHelpers;
using Domain.Entities;
using Domain.Enums;
using API.DTO;
using System.IO;
using OfficeOpenXml;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerRadiosController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerRadioRepository _answerRadioRepository;
        private readonly IResearchQuestionRepository _researchQuestionRepository;
        private readonly IResearchRepository _researchRepository;
        private readonly IAnswerRepository _answerRepository;

        public AnswerRadiosController(IMapper mapper, IUnitOfWork unitOfWork, IAnswerRadioRepository answerRadioRepository, IResearchQuestionRepository researchQuestionRepository, IResearchRepository researchRepository, IAnswerRepository answerRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _answerRadioRepository = answerRadioRepository;
            _researchQuestionRepository = researchQuestionRepository;
            _researchRepository = researchRepository;
            _answerRepository = answerRepository;
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<AnswerRadioForGetDTO>>> Get(int? id)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string role = claimsIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).FirstOrDefault()?.Value;

            if (role == RoleEnum.Admin.ToString())
            {
                List<AnswerRadioForGetDTO> answers = _mapper.Map<List<AnswerRadioForGetDTO>>(await _answerRadioRepository.GetByResearchAsync(Convert.ToInt32(id)).ConfigureAwait(true));
                return Ok(answers);
            }
            else
            {
                string researchId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;
                List<AnswerRadioForGetDTO> answers = _mapper.Map<List<AnswerRadioForGetDTO>>(await _answerRadioRepository.GetByResearchAsync(Convert.ToInt32(researchId)).ConfigureAwait(true));
                return Ok(answers);
            }

      
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Researcher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AnswerRadioForGetDTO>> Put(int id, AnswerRadioForEditDTO model)
        {
            if (id != model.Id)
                return BadRequest(new ApiResponse(400, StringConcatenates.NotEqualIds(id, model.Id)));

            if (!await _answerRadioRepository.IsExist(id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Answer", id)));

            AnswerRadio answerRadio = _mapper.Map<AnswerRadio>(model);
            AnswerRadio oldAnswerRadio = await _answerRadioRepository.GetAsync(model.Id).ConfigureAwait(true);
            answerRadio.ResearchId = oldAnswerRadio.ResearchId;

            _answerRadioRepository.Edit(answerRadio);

            var researchQuestion = await _researchQuestionRepository.GetAsync(oldAnswerRadio.ResearchId, oldAnswerRadio.QuestionId);
            var research = await _researchRepository.GetAsync(oldAnswerRadio.ResearchId);

            if (model.AnswerId == null && researchQuestion.Answered == true)
            {
                researchQuestion.Answered = false;
                _researchQuestionRepository.Edit(researchQuestion);

                research.AnswersCount--;
                _researchRepository.Edit(research);
            }
            else if (model.AnswerId != null && researchQuestion.Answered == false)
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
        public async Task<ActionResult> Init([FromForm] FileDTO model)
        {
            FileOperations.WriteFile($"uploadFiles", model.File);
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"Content/uploadFiles", model.File.FileName);
            FileInfo file = new FileInfo(path);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using ExcelPackage package = new ExcelPackage(file);
            ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
            int totalRows = workSheet.Dimension.Rows;

            var researchs = await _researchRepository.GetAsync().ConfigureAwait(true);
            var answers = await _answerRepository.GetAsync(QuestionTypeNum.Radio).ConfigureAwait(true);
            var radios = await _answerRadioRepository.GetAsync().ConfigureAwait(true);
            int colCount = workSheet.Dimension.End.Column;  //get Column Count

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
                                var radioChecked = radios.FirstOrDefault(d => d.ResearchId == research.Id && d.QuestionId == Convert.ToInt32(textSplit[0]));
                                if (radioChecked != null && Convert.ToBoolean(workSheet.Cells[i, col].Value))
                                {

                                    radioChecked.AnswerId = Convert.ToInt32(textSplit[1]);

                                    _answerRadioRepository.Edit(radioChecked);

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