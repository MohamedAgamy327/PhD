﻿using System.Collections.Generic;
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

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResearchsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IResearchRepository _researchRepository;
        private readonly IJWTManager _jwtManager;

        public ResearchsController(IMapper mapper, IUnitOfWork unitOfWork, IResearchRepository researchRepository, IJWTManager jwtManager)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _researchRepository = researchRepository;
            _jwtManager = jwtManager;
        }

        [HttpPost("Register")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> Register(ResearchForRegisterDTO model)
        {
            if (await _researchRepository.IsExist(model.Email).ConfigureAwait(true))
                return Conflict(new ApiResponse(409, StringConsts.EXISTED));

            SecurePassword.CreatePasswordHash(SecurePassword.GeneratePassword(8), out byte[] passwordHash, out byte[] passwordSalt);
            Research research = new Research
            {
                Email = model.Email,
                Name = model.Name,
                Status = ResearchStatusEnum.Pending,
                IsRandomPassword = true,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash
            };

            await _researchRepository.AddAsync(research).ConfigureAwait(true);

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            string body = "Hi: " + research.Name + "<br/>";
            body += "We have received your research, which has been passed to our specialists for review / approval. One of our representatives will be in contact soon. <br/>";
            body += "Regards, " + "<br/>";
            body += "PhD managment system";

            string subject = "Register";

            Email.Send("PhD", research.Email, subject, body);

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

            string body, subject;

            switch (status)
            {
                case ResearchStatusEnum.Accepted:
                    string ranadomPassword = SecurePassword.GeneratePassword(8);
                    SecurePassword.CreatePasswordHash(ranadomPassword, out byte[] passwordHash, out byte[] passwordSalt);
                    research.PasswordHash = passwordHash;
                    research.PasswordSalt = passwordSalt;
                    research.IsRandomPassword = true;
                    _researchRepository.Edit(research);

                    body = "Hi: " + research.Name + "<br/>";
                    body += "Your research is accepted <br/>";
                    body += "Your password is: " + ranadomPassword + "<br/>";
                    body += $"Get started from <a href={Request.Scheme}://{Request.Host}{Request.PathBase}//login target='_blank'> Here </a>" + "<br/>";
                    body += "Regards, " + "<br/>";
                    body += "PhD managment system";
                    subject = "PhD Accepted";

                    Email.Send("PhD", research.Email, subject, body);
                    break;
                case ResearchStatusEnum.Pending:

                    body = "Hi: " + research.Name + "<br/>";
                    body += "We have received your research, which has been passed to our specialists for review / approval. One of our representatives will be in contact soon. <br/>";
                    body += "Regards, " + "<br/>";
                    body += "PhD managment system";
                    subject = "PhD Pending";

                    Email.Send("PhD", research.Email, subject, body);
                    break;
                case ResearchStatusEnum.Rejected:

                    body = "Hi: " + research.Name + "<br/>";
                    body += "Your research is rejected <br/>";
                    body += "Regards, " + "<br/>";
                    body += "PhD managment system";
                    subject = "PhD Rejection";

                    Email.Send("PhD", research.Email, subject, body);
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
    }
}