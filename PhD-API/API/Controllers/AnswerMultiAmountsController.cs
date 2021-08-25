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
using API.DTO.AnswerMultiAmount;
using Domain.Entities;
using Domain.Enums;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerMultiAmountsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerMultiAmountRepository _answerMultiAmountRepository;
        private readonly IResearchQuestionRepository _researchQuestionRepository;
        private readonly IResearchRepository _researchRepository;

        public AnswerMultiAmountsController(IMapper mapper, IUnitOfWork unitOfWork, IAnswerMultiAmountRepository answerMultiAmountRepository, IResearchQuestionRepository researchQuestionRepository, IResearchRepository researchRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _answerMultiAmountRepository = answerMultiAmountRepository;
            _researchQuestionRepository = researchQuestionRepository;
            _researchRepository = researchRepository;
        }

        [HttpGet("{id}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<AnswerMultiAmountForGetDTO>>> Get(int? id)
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string role = claimsIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).FirstOrDefault()?.Value;

            if (role == RoleEnum.Admin.ToString())
            {
                List<AnswerMultiAmountForGetDTO> answers = _mapper.Map<List<AnswerMultiAmountForGetDTO>>(await _answerMultiAmountRepository.GetByResearchAsync(Convert.ToInt32(id)).ConfigureAwait(true));
                return Ok(answers);
            }
            else
            {
                string researchId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;
                List<AnswerMultiAmountForGetDTO> answers = _mapper.Map<List<AnswerMultiAmountForGetDTO>>(await _answerMultiAmountRepository.GetByResearchAsync(Convert.ToInt32(researchId)).ConfigureAwait(true));
                return Ok(answers);
            }
        }


        [HttpPut]
        [Authorize(Roles = "Researcher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<AnswerMultiAmountForGetDTO>> Put(AnswerMultiAmountForEditDTO[] list)
        {
            foreach (var model in list)
            {
                AnswerMultiAmount answerMultiAmount = _mapper.Map<AnswerMultiAmount>(model);
                AnswerMultiAmount oldAnswerMultiAmount = await _answerMultiAmountRepository.GetAsync(model.Id).ConfigureAwait(true);
                answerMultiAmount.ResearchId = oldAnswerMultiAmount.ResearchId;
                _answerMultiAmountRepository.Edit(answerMultiAmount);
            }



            var claimsIdentity = User.Identity as ClaimsIdentity;
            string researchId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;

            var researchQuestion = await _researchQuestionRepository.GetAsync(Convert.ToInt32(researchId), list[0].QuestionId);
            var research = await _researchRepository.GetAsync(Convert.ToInt32(researchId));

            if (list.All(d => d.Amount == null) && researchQuestion.Answered == true)
            {
                researchQuestion.Answered = false;
                _researchQuestionRepository.Edit(researchQuestion);

                research.AnswersCount--;
                _researchRepository.Edit(research);
            }
            else if (list.Any(d => d.Amount != null) && researchQuestion.Answered == false)
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