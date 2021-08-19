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
using API.DTO.AnswerMultiAmount;
using Domain.Entities;

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

        public AnswerMultiAmountsController(IMapper mapper, IUnitOfWork unitOfWork, IAnswerMultiAmountRepository answerMultiAmountRepository, IResearchQuestionRepository researchQuestionRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _answerMultiAmountRepository = answerMultiAmountRepository;
            _researchQuestionRepository = researchQuestionRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Researcher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<AnswerMultiAmountForGetDTO>>> Get()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;
            List<AnswerMultiAmountForGetDTO> answers = _mapper.Map<List<AnswerMultiAmountForGetDTO>>(await _answerMultiAmountRepository.GetByResearchAsync(Convert.ToInt32(userId)).ConfigureAwait(true));
            return Ok(answers);
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

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            return Ok();
        }

    }
}