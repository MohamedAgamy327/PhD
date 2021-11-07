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
using API.DTO.AnswerNumber;
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
    public class AnswerNumbersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerNumberRepository _answerNumberRepository;
        private readonly IResearchQuestionRepository _researchQuestionRepository;
        private readonly IResearchRepository _researchRepository;

        public AnswerNumbersController(IMapper mapper, IUnitOfWork unitOfWork, IAnswerNumberRepository answerNumberRepository, IResearchQuestionRepository researchQuestionRepository, IResearchRepository researchRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _answerNumberRepository = answerNumberRepository;
            _researchQuestionRepository = researchQuestionRepository;
            _researchRepository = researchRepository;
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<AnswerNumberForGetDTO>>> Get(int? id)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string role = claimsIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).FirstOrDefault()?.Value;

            if (role == RoleEnum.Admin.ToString())
            {
                List<AnswerNumberForGetDTO> answers = _mapper.Map<List<AnswerNumberForGetDTO>>(await _answerNumberRepository.GetByResearchAsync(Convert.ToInt32(id)).ConfigureAwait(true));
                return Ok(answers);
            }
            else
            {
                string researchId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;
                List<AnswerNumberForGetDTO> answers = _mapper.Map<List<AnswerNumberForGetDTO>>(await _answerNumberRepository.GetByResearchAsync(Convert.ToInt32(researchId)).ConfigureAwait(true));
                return Ok(answers);
            }
        }


        [HttpPut("{id}")]
        [Authorize(Roles = "Researcher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AnswerNumberForGetDTO>> Put(int id, AnswerNumberForEditDTO model)
        {
            if (id != model.Id)
                return BadRequest(new ApiResponse(400, StringConcatenates.NotEqualIds(id, model.Id)));

            if (!await _answerNumberRepository.IsExist(id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Answer", id)));

            AnswerNumber answerNumber = _mapper.Map<AnswerNumber>(model);
            AnswerNumber oldAnswerNumber = await _answerNumberRepository.GetAsync(model.Id).ConfigureAwait(true);
            answerNumber.ResearchId = oldAnswerNumber.ResearchId;

            _answerNumberRepository.Edit(answerNumber);

            var researchQuestion = await _researchQuestionRepository.GetAsync(oldAnswerNumber.ResearchId, oldAnswerNumber.QuestionId);

            var research = await _researchRepository.GetAsync(oldAnswerNumber.ResearchId);

            if (model.Number == null && researchQuestion.Answered == true)
            {
                researchQuestion.Answered = false;
                _researchQuestionRepository.Edit(researchQuestion);

                research.AnswersCount--;
                _researchRepository.Edit(research);
            }
            else if (model.Number != null && researchQuestion.Answered == false)
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
        public async Task<ActionResult<AnswerNumberForGetDTO>> Init([FromForm] FileDTO model)
        {

            var researchs = await _researchRepository.GetAsync().ConfigureAwait(true);

            FileOperations.WriteFile($"uploadFiles", model.File);
            string path = Path.Combine(Directory.GetCurrentDirectory(), $"Content/uploadFiles", model.File.FileName);
            FileInfo file = new FileInfo(path);
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using ExcelPackage package = new ExcelPackage(file);
            ExcelWorksheet workSheet = package.Workbook.Worksheets[0];
            int totalRows = workSheet.Dimension.Rows;

            for (int i = 5; i <= totalRows; i++)
            {
                try
                {
                    Research research = researchs.FirstOrDefault(f => f.Code == Convert.ToInt32(workSheet.Cells[i, 1].Value));
                    var researchQuestion = await _researchQuestionRepository.GetAsync(research.Id, 5);
                    researchQuestion.Answered = true;
                    AnswerNumber answerNumber = await _answerNumberRepository.GetAsync(research.Id,5).ConfigureAwait(true);
                    answerNumber.Number= Convert.ToInt32(workSheet.Cells[i, 27].Value);
                    _answerNumberRepository.Edit(answerNumber);
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