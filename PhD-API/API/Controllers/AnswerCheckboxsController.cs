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
using API.DTO.AnswerCheckbox;
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
    public class AnswerCheckboxsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerRepository _answerRepository;
        private readonly IAnswerCheckboxRepository _answerCheckboxRepository;
        private readonly IResearchQuestionRepository _researchQuestionRepository;
        private readonly IResearchRepository _researchRepository;
        public AnswerCheckboxsController(IMapper mapper, IUnitOfWork unitOfWork, IAnswerCheckboxRepository answerCheckboxRepository, IResearchQuestionRepository researchQuestionRepository, IResearchRepository researchRepository, IAnswerRepository answerRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _answerCheckboxRepository = answerCheckboxRepository;
            _researchQuestionRepository = researchQuestionRepository;
            _researchRepository = researchRepository;
            _answerRepository = answerRepository;
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<AnswerCheckboxForGetDTO>>> Get(int? id)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string role = claimsIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).FirstOrDefault()?.Value;

            if (role == RoleEnum.Admin.ToString())
            {
                List<AnswerCheckboxForGetDTO> answers = _mapper.Map<List<AnswerCheckboxForGetDTO>>(await _answerCheckboxRepository.GetByResearchAsync(Convert.ToInt32(id)).ConfigureAwait(true));
                return Ok(answers);
            }
            else
            {
                string researchId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;
                List<AnswerCheckboxForGetDTO> answers = _mapper.Map<List<AnswerCheckboxForGetDTO>>(await _answerCheckboxRepository.GetByResearchAsync(Convert.ToInt32(researchId)).ConfigureAwait(true));
                return Ok(answers);
            }
        }

        [HttpPut]
        [Authorize(Roles = "Researcher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AnswerCheckboxForGetDTO>> Put(AnswerCheckboxForEditDTO[] list)
        {
            foreach (var model in list)
            {
                AnswerCheckbox answerCheckbox = _mapper.Map<AnswerCheckbox>(model);
                AnswerCheckbox oldAnswerCheckbox = await _answerCheckboxRepository.GetAsync(model.Id).ConfigureAwait(true);
                answerCheckbox.ResearchId = oldAnswerCheckbox.ResearchId;
                _answerCheckboxRepository.Edit(answerCheckbox);
            }

            var claimsIdentity = User.Identity as ClaimsIdentity;
            string researchId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;

            var researchQuestion = await _researchQuestionRepository.GetAsync(Convert.ToInt32(researchId), list[0].QuestionId);

            var research = await _researchRepository.GetAsync(Convert.ToInt32(researchId));

            if (list.All(d => d.Checked == false) && researchQuestion.Answered == true)
            {
                researchQuestion.Answered = false;
                _researchQuestionRepository.Edit(researchQuestion);

                research.AnswersCount--;
                _researchRepository.Edit(research);

            }
            else if (list.Any(d => d.Checked == true) && researchQuestion.Answered == false)
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
            var answers = await _answerRepository.GetAsync(QuestionTypeNum.Checkbox).ConfigureAwait(true);
            var checkboxes = await _answerCheckboxRepository.GetAsync().ConfigureAwait(true);
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
                                var answerChecked = checkboxes.FirstOrDefault(d => d.ResearchId == research.Id && d.AnswerId == Convert.ToInt32(textSplit[1]));
                                if (answerChecked != null)
                                {
                                    answerChecked.Checked = Convert.ToBoolean(workSheet.Cells[i, col].Value);

                                    _answerCheckboxRepository.Edit(answerChecked);
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