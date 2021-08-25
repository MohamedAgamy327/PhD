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
using API.DTO.AnswerMultiPercentage;
using Domain.Entities;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerMultiPercentagesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerMultiPercentageRepository _answerMultiPercentageRepository;
        private readonly IResearchQuestionRepository _researchQuestionRepository;
        private readonly IResearchRepository _researchRepository;

        public AnswerMultiPercentagesController(IMapper mapper, IUnitOfWork unitOfWork, IAnswerMultiPercentageRepository answerMultiPercentageRepository, IResearchQuestionRepository researchQuestionRepository, IResearchRepository researchRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _answerMultiPercentageRepository = answerMultiPercentageRepository;
            _researchQuestionRepository = researchQuestionRepository;
            _researchRepository = researchRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Researcher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<AnswerMultiPercentageForGetDTO>>> Get()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;
            List<AnswerMultiPercentageForGetDTO> answers = _mapper.Map<List<AnswerMultiPercentageForGetDTO>>(await _answerMultiPercentageRepository.GetByResearchAsync(Convert.ToInt32(userId)).ConfigureAwait(true));
            return Ok(answers);
        }


        [HttpPut]
        [Authorize(Roles = "Researcher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AnswerMultiPercentageForGetDTO>> Put(AnswerMultiPercentageForEditDTO[] list)
        {
            foreach (var model in list)
            {
                AnswerMultiPercentage answerMultiPercentage = _mapper.Map<AnswerMultiPercentage>(model);
                answerMultiPercentage.Radio = Convert.ToBoolean(list[0].Radio);
                AnswerMultiPercentage oldAnswerMultiPercentage = await _answerMultiPercentageRepository.GetAsync(model.Id).ConfigureAwait(true);
                answerMultiPercentage.ResearchId = oldAnswerMultiPercentage.ResearchId;
                _answerMultiPercentageRepository.Edit(answerMultiPercentage);
            }


            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;

            var researchQuestion = await _researchQuestionRepository.GetAsync(Convert.ToInt32(userId), list[0].QuestionId);
            var research = await _researchRepository.GetAsync(Convert.ToInt32(userId));

            if (Convert.ToBoolean(list[0].Radio) == false && researchQuestion.Answered == false)
            {
                researchQuestion.Answered = true;
                _researchQuestionRepository.Edit(researchQuestion);

                research.AnswersCount++;
                _researchRepository.Edit(research);
            }
            else if (Convert.ToBoolean(list[0].Radio) == true &&  (list.Any(d => d.Number1 != null) || list.Any(d => d.Number2 != null)) && researchQuestion.Answered == false)
            {
                researchQuestion.Answered = true;
                _researchQuestionRepository.Edit(researchQuestion);

                research.AnswersCount++;
                _researchRepository.Edit(research);
            }
            else if (Convert.ToBoolean(list[0].Radio) == true &&  list.All(d => d.Number1 == null) && list.All(d => d.Number2 == null) && researchQuestion.Answered == true)
            {
                researchQuestion.Answered = false;
                _researchQuestionRepository.Edit(researchQuestion);

                research.AnswersCount--;
                _researchRepository.Edit(research);
            }

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            return Ok(research.AnswersCount);
        }

    }
}