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

        public AnswerMultiCheckboxsController(IMapper mapper, IUnitOfWork unitOfWork, IAnswerMultiCheckboxRepository answerMultiCheckboxRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _answerMultiCheckboxRepository = answerMultiCheckboxRepository;
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

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            return Ok();
        }

    }
}