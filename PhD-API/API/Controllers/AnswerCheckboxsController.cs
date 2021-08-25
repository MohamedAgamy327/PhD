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

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerCheckboxsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerCheckboxRepository _answerCheckboxRepository;
        private readonly IResearchQuestionRepository _researchQuestionRepository;
        private readonly IResearchRepository _researchRepository;
        public AnswerCheckboxsController(IMapper mapper, IUnitOfWork unitOfWork, IAnswerCheckboxRepository answerCheckboxRepository, IResearchQuestionRepository researchQuestionRepository, IResearchRepository researchRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _answerCheckboxRepository = answerCheckboxRepository;
            _researchQuestionRepository = researchQuestionRepository;
            _researchRepository = researchRepository;
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

    }
}