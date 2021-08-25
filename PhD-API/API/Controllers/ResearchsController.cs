using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Research;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.UnitOfWork;
using System;
using Core.IRepository;
using Microsoft.AspNetCore.Http;
using API.Errors;
using Utilities.StaticHelpers;
using Domain.Enums;
using API.IHelpers;
using Microsoft.AspNetCore.Authorization;
using API.DTO.Account;
using API.IService;
using System.Security.Claims;
using System.Linq;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IResearchRepository _researchRepository;
        private readonly IResearchService _researchService;
        private readonly IAnswerRadioService _answerRadioService;
        private readonly IAnswerNumberService _answerNumberService;
        private readonly IAnswerCheckboxService _answerCheckboxService;
        private readonly IAnswerMultiAmountService _answerMultiAmountService;
        private readonly IAnswerMultiPercentageService _answerMultiPercentageService;
        private readonly IAnswerMultiCheckboxService _answerMultiCheckboxService;
        private readonly IResearchQuestionService _researchQuestionService;
        private readonly IJWTManager _jwtManager;

        public ResearchsController(IMapper mapper, IUnitOfWork unitOfWork, IResearchRepository researchRepository, IJWTManager jwtManager, IResearchService researchService, IAnswerRadioService answerRadioService, IAnswerCheckboxService answerCheckboxService, IAnswerNumberService answerNumberService, IAnswerMultiAmountService answerMultiAmountService, IAnswerMultiPercentageService answerMultiPercentageService, IAnswerMultiCheckboxService answerMultiCheckboxService, IResearchQuestionService researchQuestionService)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _researchRepository = researchRepository;
            _jwtManager = jwtManager;
            _researchService = researchService;
            _answerRadioService = answerRadioService;
            _answerCheckboxService = answerCheckboxService;
            _answerNumberService = answerNumberService;
            _answerMultiAmountService = answerMultiAmountService;
            _answerMultiPercentageService = answerMultiPercentageService;
            _answerMultiCheckboxService = answerMultiCheckboxService;
            _researchQuestionService = researchQuestionService;
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register(ResearchForRegisterDTO model)
        {
            if (await _researchRepository.IsExist(model.Email).ConfigureAwait(true))
                return Conflict(new ApiResponse(409, StringConsts.EXISTED));

            Research research = _mapper.Map<Research>(model);

            SecurePassword.CreatePasswordHash(SecurePassword.GeneratePassword(8), out byte[] passwordHash, out byte[] passwordSalt);
            research.PasswordSalt = passwordSalt;
            research.PasswordHash = passwordHash;

            await _researchRepository.AddAsync(research).ConfigureAwait(true);

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);


            Email.Send("PhD", research.Email, "Register", _researchService.CreateRegisterMailTemplate(research.Name));

            return Ok();
        }

        [HttpPatch("{id}/ChangePassword")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResearchForGetDTO>> ChangePassword(int id, ResearchForChangePasswordDTO model)
        {
            if (id != model.Id)
                return BadRequest(new ApiResponse(400, StringConcatenates.NotEqualIds(id, model.Id)));

            if (!await _researchRepository.IsExist(id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Research", id)));

            Research research = await _researchRepository.GetAsync(model.Id).ConfigureAwait(true);
            SecurePassword.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
            research.PasswordHash = passwordHash;
            research.PasswordSalt = passwordSalt;
            research.IsRandomPassword = false;

            _researchRepository.Edit(research);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            return Ok(new TokenDTO { Token = _jwtManager.GenerateToken(research) });

        }

        [HttpPatch("status")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResearchForGetDTO>> PatchStatus(ResearchForStatusDTO model)
        {

            if (!await _researchRepository.IsExist(model.Id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Research", model.Id)));

            Research research = await _researchRepository.GetAsync(model.Id).ConfigureAwait(true);
            Enum.TryParse(model.Status, out ResearchStatusEnum status);
            research.Status = status;
            _researchRepository.Edit(research);

            switch (status)
            {
                case ResearchStatusEnum.Accepted:
                    string ranadomPassword = SecurePassword.GeneratePassword(8);
                    SecurePassword.CreatePasswordHash(ranadomPassword, out byte[] passwordHash, out byte[] passwordSalt);
                    research.PasswordHash = passwordHash;
                    research.PasswordSalt = passwordSalt;
                    research.IsRandomPassword = true;
                    _researchRepository.Edit(research);

                    await _answerRadioService.AddInitAnswer(research.Id).ConfigureAwait(true);
                    await _answerCheckboxService.AddInitAnswer(research.Id).ConfigureAwait(true);
                    await _answerNumberService.AddInitAnswer(research.Id).ConfigureAwait(true);
                    await _answerMultiAmountService.AddInitAnswer(research.Id).ConfigureAwait(true);
                    await _answerMultiPercentageService.AddInitAnswer(research.Id).ConfigureAwait(true);
                    await _answerMultiCheckboxService.AddInitAnswer(research.Id).ConfigureAwait(true);
                    await _researchQuestionService.AddInitResearchQuestions(research.Id).ConfigureAwait(true);

                    Email.Send("PhD", research.Email, "PhD Accepted", _researchService.CreateAcceptMailTemplate(research, _jwtManager.GenerateToken(research), ranadomPassword, Request));
                    break;

                case ResearchStatusEnum.Pending:

                    Email.Send("PhD", research.Email, "PhD Pending", _researchService.CreatePendingMailTemplate(research.Name));
                    break;

                case ResearchStatusEnum.Rejected:

                    Email.Send("PhD", research.Email, "PhD Rejection", _researchService.CreateRejectedMailTemplate(research.Name));
                    break;
            }

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);
            ResearchForGetDTO researchDto = _mapper.Map<ResearchForGetDTO>(research);
            return Ok(researchDto);
        }

        [HttpGet]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ResearchForGetDTO>>> Get()
        {
            List<ResearchForGetDTO> researchs = _mapper.Map<List<ResearchForGetDTO>>(await _researchRepository.GetAsync().ConfigureAwait(true));
            return Ok(researchs);
        }

        [HttpGet("{status}")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ResearchForGetDTO>>> Get(string status)
        {
            Enum.TryParse(status, out ResearchStatusEnum myStatus);
            List<ResearchForGetDTO> researchs = _mapper.Map<List<ResearchForGetDTO>>(await _researchRepository.GetAsync(myStatus).ConfigureAwait(true));
            return Ok(researchs);
        }


        [HttpGet("own")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResearchForGetDTO>> GetOwn()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;

            Research research = await _researchRepository.GetAsync(Convert.ToInt32(userId)).ConfigureAwait(true);

            ResearchForGetDTO researchDto = _mapper.Map<ResearchForGetDTO>(research);
            return Ok(researchDto);
        }

        [HttpGet("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResearchForGetDTO>> Get(int id)
        {
            if (!await _researchRepository.IsExist(id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Research", id)));

            Research research = await _researchRepository.GetAsync(id).ConfigureAwait(true);

            ResearchForGetDTO researchDto = _mapper.Map<ResearchForGetDTO>(research);
            return Ok(researchDto);
        }

        [HttpDelete("{id:int}")]
        [Authorize(Roles = "Admin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResearchForGetDTO>> Delete(int id)
        {
            if (!await _researchRepository.IsExist(id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Research", id)));

            Research research = await _researchRepository.GetAsync(id).ConfigureAwait(true);

            _researchRepository.Remove(research);

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            ResearchForGetDTO researchDto = _mapper.Map<ResearchForGetDTO>(research);
            return Ok(researchDto);
        }
    }
}