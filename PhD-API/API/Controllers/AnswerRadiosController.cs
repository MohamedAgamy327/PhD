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

        public AnswerRadiosController(IMapper mapper, IUnitOfWork unitOfWork, IAnswerRadioRepository answerRadioRepository, IResearchQuestionRepository researchQuestionRepository, IResearchRepository researchRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _answerRadioRepository = answerRadioRepository;
            _researchQuestionRepository = researchQuestionRepository;
            _researchRepository = researchRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Researcher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<AnswerRadioForGetDTO>>> Get()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;
            List<AnswerRadioForGetDTO> answers = _mapper.Map<List<AnswerRadioForGetDTO>>(await _answerRadioRepository.GetByResearchAsync(Convert.ToInt32(userId)).ConfigureAwait(true));
            return Ok(answers);
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

    }
}