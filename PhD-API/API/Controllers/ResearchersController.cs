using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Researcher;
using API.IHelpers;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.UnitOfWork;
using System;
using Core.IRepository;
using Microsoft.AspNetCore.Http;
using API.DTO.Account;
using API.Errors;
using Utilities.StaticHelpers;
using Domain.Enums;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJWTManager _jwtManager;
        private readonly IResearcherRepository _researcherRepository;

        public ResearchersController(IMapper mapper, IJWTManager jwtManager, IUnitOfWork unitOfWork, IResearcherRepository researcherRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _jwtManager = jwtManager;
            _researcherRepository = researcherRepository;
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register(ResearcherForRegisterDTO model)
        {
            if (await _researcherRepository.IsExist(model.Email).ConfigureAwait(true))
                return Conflict(new ApiResponse(409, StringConsts.EXISTED));

            Researcher researcher = _mapper.Map<Researcher>(model);
            string ranadomPassword = SecurePassword.GeneratePassword(8);
            SecurePassword.CreatePasswordHash(SecurePassword.GeneratePassword(8), out byte[] passwordHash, out byte[] passwordSalt);
            researcher.PasswordHash = passwordHash;
            researcher.PasswordSalt = passwordSalt;

            await _researcherRepository.AddAsync(researcher).ConfigureAwait(true);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            Email.Send("PhD", "mohamedagamy327@gmail.com", "Register", ranadomPassword);

            return Ok();
        }

        [HttpPost("login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TokenDTO>> Login(ResearcherForLoginDTO model)
        {
            Researcher researcher = await _researcherRepository.LoginAsync(model.Email, model.Password).ConfigureAwait(true);

            if (researcher == null)
                return Unauthorized(new ApiResponse(401, StringConsts.UNAUTHORIZED));

            return Ok(new TokenDTO { Token = _jwtManager.GenerateToken(researcher) });
        }

        [HttpPatch("searchStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResearcherForGetDTO>> PatchStatus( ResearcherForStatusDTO model)
        {

            if (!await _researcherRepository.IsExist(model.Id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Researcher", model.Id)));

            Researcher researcher = await _researcherRepository.GetAsync(model.Id).ConfigureAwait(true);
            Enum.TryParse(model.SearchStatus, out SearchStatusEnum status);
            researcher.SearchStatus = status;
            _researcherRepository.Edit(researcher);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);


            switch (status)
            {
                case SearchStatusEnum.Pending:
                    Email.Send("PhD", "mohamedagamy327@gmail.com", SearchStatusEnum.Pending.ToString(), SearchStatusEnum.Pending.ToString());
                    break;
                case SearchStatusEnum.Accepted:
                    Email.Send("PhD", "mohamedagamy327@gmail.com", SearchStatusEnum.Accepted.ToString(), SearchStatusEnum.Accepted.ToString());
                    break;
                case SearchStatusEnum.Rejected:
                    Email.Send("PhD", "mohamedagamy327@gmail.com", SearchStatusEnum.Rejected.ToString(), SearchStatusEnum.Rejected.ToString());
                    break;
            }




            ResearcherForGetDTO researcherDto = _mapper.Map<ResearcherForGetDTO>(researcher);
            return Ok(researcherDto);
        }

        [HttpPatch("{id}/ChangePassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> ChangePassword(int id, ResearcherForChangePasswordDTO model)
        {
            if (id != model.Id)
                return BadRequest(new ApiResponse(400, StringConcatenates.NotEqualIds(id, model.Id)));

            if (!await _researcherRepository.IsExist(id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Researcher", id)));

            Researcher researcher = await _researcherRepository.GetAsync(model.Id).ConfigureAwait(true);
            SecurePassword.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
            researcher.PasswordHash = passwordHash;
            researcher.PasswordSalt = passwordSalt;
            researcher.IsRandomPassword = false;

            _researcherRepository.Edit(researcher);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            return Ok(new TokenDTO { Token = _jwtManager.GenerateToken(researcher) });

        }


        [HttpGet("{searchStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ResearcherForGetDTO>>> Get(string searchStatus)
        {

            Enum.TryParse(searchStatus, out SearchStatusEnum myStatus);
            List<ResearcherForGetDTO> researchers = _mapper.Map<List<ResearcherForGetDTO>>(await _researcherRepository.GetAsync(myStatus).ConfigureAwait(true));
            return Ok(researchers);
        }
    }
}