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
                Email = model.Email,
                Name = model.Name,
                Role = RoleEnum.Researcher,
                IsRandomPassword = true,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
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

            string body = "Hi: " + user.Name + "<br/>";
            body += "We have received your research, which has been passed to our specialists for review / approval. One of our representatives will be in contact soon. <br/>";
            body += "Regards, " + "<br/>";
            body += "PhD managment system";

            string subject = "Register";

            Email.Send("PhD", user.Email, subject, body);

            return Ok();
        }

        [HttpPatch("searchStatus")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<ResearchForGetDTO>> PatchStatus(ResearchForStatusDTO model)
        {

            if (!await _researcherRepository.IsExist(model.Id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Research", model.Id)));

            Research researcher = await _researcherRepository.GetAsync(model.Id).ConfigureAwait(true);
            Enum.TryParse(model.SearchStatus, out SearchStatusEnum status);
            researcher.SearchStatus = status;
            _researcherRepository.Edit(researcher);
            string body, subject;
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

                    body = "Hi: " + user.Name + "<br/>";
                    body += "Your research is accepted <br/>";
                    body += "Your password is: " + ranadomPassword + "<br/>";
                    body += "Regards, " + "<br/>";
                    body += "PhD managment system";
                    subject = "PhD Accepted";

                    Email.Send("PhD", researcher.User.Email, subject, body);
                    break;
                case SearchStatusEnum.Pending:

                    body = "Hi: " + researcher.User.Name + "<br/>";
                    body += "We have received your research, which has been passed to our specialists for review / approval. One of our representatives will be in contact soon. <br/>";
                    body += "Regards, " + "<br/>";
                    body += "PhD managment system";
                    subject = "PhD Pending";

                    Email.Send("PhD", researcher.User.Email, subject, body);
                    break;
                case SearchStatusEnum.Rejected:

                    body = "Hi: " + researcher.User.Name + "<br/>";
                    body += "Your research is rejected <br/>";
                    body += "Regards, " + "<br/>";
                    body += "PhD managment system";
                    subject = "PhD Rejection";

                    Email.Send("PhD", researcher.User.Email, subject, body);
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