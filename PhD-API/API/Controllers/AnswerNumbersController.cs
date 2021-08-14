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


namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnswerNumbersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerNumberRepository _answerNumberRepository;

        public AnswerNumbersController(IMapper mapper, IUnitOfWork unitOfWork, IAnswerNumberRepository answerNumberRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _answerNumberRepository = answerNumberRepository;
        }

        [HttpGet]
        [Authorize(Roles = "Researcher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<AnswerNumberForGetDTO>>> Get()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;
            List<AnswerNumberForGetDTO> answers = _mapper.Map<List<AnswerNumberForGetDTO>>(await _answerNumberRepository.GetByResearchAsync(Convert.ToInt32(userId)).ConfigureAwait(true));
            return Ok(answers);
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
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            AnswerNumberForGetDTO answerNumberDto = _mapper.Map<AnswerNumberForGetDTO>(answerNumber);
            return Ok(answerNumberDto);
        }

    }
}