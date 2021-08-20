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

        public AnswerMultiCheckboxsController(IMapper mapper, IUnitOfWork unitOfWork, IAnswerMultiCheckboxRepository answerMultiCheckboxRepository, IResearchQuestionRepository researchQuestionRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _answerMultiCheckboxRepository = answerMultiCheckboxRepository;
            _researchQuestionRepository = researchQuestionRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Researcher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<AnswerMultiCheckboxForGetDTO>>> Get()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;
            List<AnswerMultiCheckboxForGetDTO> answers = _mapper.Map<List<AnswerMultiCheckboxForGetDTO>>(await _answerMultiCheckboxRepository.GetByResearchAsync(Convert.ToInt32(userId)).ConfigureAwait(true));
            return Ok(answers);
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
            string userId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;

            var researchQuestion = await _researchQuestionRepository.GetAsync(Convert.ToInt32(userId), list[0].QuestionId);

            if (Convert.ToBoolean(list[0].Radio) == false && researchQuestion == null)
            {
                await _researchQuestionRepository.AddAsync(new ResearchQuestion
                {
                    QuestionId = list[0].QuestionId,
                    ResearchId = Convert.ToInt32(userId)
                });
            }
            else if (Convert.ToBoolean(list[0].Radio) == true && researchQuestion == null && (list.Any(d => d.Checked1) || list.Any(d => d.Checked2)))
            {
                await _researchQuestionRepository.AddAsync(new ResearchQuestion
                {
                    QuestionId = list[0].QuestionId,
                    ResearchId = Convert.ToInt32(userId)
                });
            }
            else if (Convert.ToBoolean(list[0].Radio) == true && researchQuestion != null && list.All(d => d.Checked1 == false) && list.All(d => d.Checked2 == false))
            {
                _researchQuestionRepository.Remove(researchQuestion);
            }


            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            return Ok(await _researchQuestionRepository.GetCountAsync(Convert.ToInt32(userId)));
        }

    }
}