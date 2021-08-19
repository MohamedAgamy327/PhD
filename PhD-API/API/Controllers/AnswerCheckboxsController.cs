﻿using System.Collections.Generic;
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
        public AnswerCheckboxsController(IMapper mapper, IUnitOfWork unitOfWork, IAnswerCheckboxRepository answerCheckboxRepository, IResearchQuestionRepository researchQuestionRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _answerCheckboxRepository = answerCheckboxRepository;
            _researchQuestionRepository = researchQuestionRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Researcher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<AnswerCheckboxForGetDTO>>> Get()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;
            List<AnswerCheckboxForGetDTO> answers = _mapper.Map<List<AnswerCheckboxForGetDTO>>(await _answerCheckboxRepository.GetByResearchAsync(Convert.ToInt32(userId)).ConfigureAwait(true));
            return Ok(answers);
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
            string userId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;

            var researchQuestion = await _researchQuestionRepository.GetAsync(Convert.ToInt32(userId), list[0].QuestionId);

            if (list.All(d => d.Checked == false) && researchQuestion != null)
            {
                _researchQuestionRepository.Remove(researchQuestion);
            }
            else if (list.Any(d => d.Checked == true) && researchQuestion == null)
            {
                await _researchQuestionRepository.AddAsync(new ResearchQuestion
                {
                    QuestionId = list[0].QuestionId,
                    ResearchId = Convert.ToInt32(userId)
                });
            }

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);


            return Ok(await _researchQuestionRepository.GetCountAsync(Convert.ToInt32(userId)));
        }

    }
}