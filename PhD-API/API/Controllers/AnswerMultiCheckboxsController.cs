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

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerMultiCheckboxsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerMultiCheckboxRepository _answerMultiCheckboxRepository;
        private readonly IResearchQuestionRepository _researchQuestionRepository;
        private readonly IResearchRepository _researchRepository;

        public AnswerMultiCheckboxsController(IMapper mapper, IUnitOfWork unitOfWork, IAnswerMultiCheckboxRepository answerMultiCheckboxRepository, IResearchQuestionRepository researchQuestionRepository, IResearchRepository researchRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _answerMultiCheckboxRepository = answerMultiCheckboxRepository;
            _researchQuestionRepository = researchQuestionRepository;
            _researchRepository = researchRepository;
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
            else if (Convert.ToBoolean(list[0].Radio) == true  && (list.Any(d => d.Checked1) || list.Any(d => d.Checked2)) && researchQuestion.Answered == false)
            {
                researchQuestion.Answered = true;
                _researchQuestionRepository.Edit(researchQuestion);

                research.AnswersCount++;
                _researchRepository.Edit(research);
            }
            else if (Convert.ToBoolean(list[0].Radio) == true &&  list.All(d => d.Checked1 == false) && list.All(d => d.Checked2 == false) && researchQuestion.Answered == true)
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