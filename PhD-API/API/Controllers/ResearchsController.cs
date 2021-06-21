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

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IResearchRepository _researcherRepository;

        public ResearchsController(IMapper mapper, IUnitOfWork unitOfWork, IResearchRepository researcherRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _researcherRepository = researcherRepository;
            _userRepository = userRepository;
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register(ResearchForRegisterDTO model)
        {          
            SecurePassword.CreatePasswordHash(SecurePassword.GeneratePassword(8), out byte[] passwordHash, out byte[] passwordSalt);
            User user = new User
            {
                Email=model.Email,
                Name=model.Name,
                Role=RoleEnum.Researcher,
                IsRandomPassword=true,
                PasswordSalt=passwordSalt,
                PasswordHash=passwordHash
            };

            await _userRepository.AddAsync(user).ConfigureAwait(true);

            Research research = new Research
            {
                SearchStatus = SearchStatusEnum.Pending,
                User = user,
                UserId = user.Id
            };

            await _researcherRepository.AddAsync(research).ConfigureAwait(true);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            Email.Send("PhD", "mohamedagamy327@gmail.com", "Register", "Welcome Pending");

            return Ok();
        }

        [HttpPatch("searchStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResearchForGetDTO>> PatchStatus( ResearchForStatusDTO model)
        {

            if (!await _researcherRepository.IsExist(model.Id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Research", model.Id)));

            Research researcher = await _researcherRepository.GetAsync(model.Id).ConfigureAwait(true);
            Enum.TryParse(model.SearchStatus, out SearchStatusEnum status);
            researcher.SearchStatus = status;
            _researcherRepository.Edit(researcher);

            switch (status)
            {
                case SearchStatusEnum.Accepted:
                    string ranadomPassword = SecurePassword.GeneratePassword(8);
                    User user = await _userRepository.GetAsync(researcher.UserId).ConfigureAwait(true);
                    SecurePassword.CreatePasswordHash(ranadomPassword, out byte[] passwordHash, out byte[] passwordSalt);
                    user.PasswordHash = passwordHash;
                    user.PasswordSalt = passwordSalt;
                    user.IsRandomPassword = true;
                    _userRepository.Edit(user);
                    Email.Send("PhD", "mohamedagamy327@gmail.com", SearchStatusEnum.Accepted.ToString(),$"{SearchStatusEnum.Accepted.ToString()} password is: {ranadomPassword}");
                    break;
                case SearchStatusEnum.Pending:
                    Email.Send("PhD", "mohamedagamy327@gmail.com", SearchStatusEnum.Pending.ToString(), SearchStatusEnum.Pending.ToString());
                    break;
                case SearchStatusEnum.Rejected:
                    Email.Send("PhD", "mohamedagamy327@gmail.com", SearchStatusEnum.Rejected.ToString(), SearchStatusEnum.Rejected.ToString());
                    break;
            }

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);
            ResearchForGetDTO researcherDto = _mapper.Map<ResearchForGetDTO>(researcher);
            return Ok(researcherDto);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ResearchForGetDTO>>> Get()
        {
            List<ResearchForGetDTO> researchers = _mapper.Map<List<ResearchForGetDTO>>(await _researcherRepository.GetAsync().ConfigureAwait(true));
            return Ok(researchers);
        }

        [HttpGet("{searchStatus}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<ResearchForGetDTO>>> Get(string searchStatus)
        {
            Enum.TryParse(searchStatus, out SearchStatusEnum myStatus);
            List<ResearchForGetDTO> researchers = _mapper.Map<List<ResearchForGetDTO>>(await _researcherRepository.GetAsync(myStatus).ConfigureAwait(true));
            return Ok(researchers);
        }
    }
}