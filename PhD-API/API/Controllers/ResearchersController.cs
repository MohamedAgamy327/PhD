using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Researcher;
using API.IHelpers;
using AutoMapper;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Core.UnitOfWork;
using System.Security.Claims;
using System.Linq;
using System;
using Microsoft.AspNetCore.Authorization;
using Core.IRepository;
using Microsoft.AspNetCore.Http;
using API.DTO.Account;
using API.Errors;
using Utilities.StaticHelpers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class ResearchersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJWTManager _jwtManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IResearcherRepository _researcherRepository;

        public ResearchersController(IJWTManager jwtManager, IMapper mapper, IUnitOfWork unitOfWork, IResearcherRepository researcherRepository)
        {
            _mapper = mapper;
            _jwtManager = jwtManager;
            _unitOfWork = unitOfWork;
            _researcherRepository = researcherRepository;
        }

        //[HttpPost]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<ResearcherForGetDTO>> Post(ResearcherForAddDTO model)
        //{
        //    if (await _researcherRepository.IsExist(model.Name).ConfigureAwait(true))
        //        return Conflict(new ApiResponse(409, StringConsts.EXISTED));

        //    Researcher researcher = _mapper.Map<Researcher>(model);
        //    SecurePassword.CreatePasswordHash("123123", out byte[] passwordHash, out byte[] passwordSalt);
        //    researcher.PasswordHash = passwordHash;
        //    researcher.PasswordSalt = passwordSalt;

        //    await _researcherRepository.AddAsync(researcher).ConfigureAwait(true);
        //    await _unitOfWork.CompleteAsync().ConfigureAwait(true);

        //    ResearcherForGetDTO researcherDto = _mapper.Map<ResearcherForGetDTO>(researcher);
        //    return Ok(researcherDto);
        //}

        //[HttpPut("{id}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<ResearcherForGetDTO>> Put(int id, ResearcherForEditDTO model)
        //{
        //    if (id != model.Id)
        //        return BadRequest(new ApiResponse(400, StringConcatenates.NotEqualIds(id, model.Id)));

        //    if (!await _researcherRepository.IsExist(id).ConfigureAwait(true))
        //        return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Researcher",id)));

        //    if (await _researcherRepository.IsExist(model.Id, model.Name).ConfigureAwait(true))
        //        return Conflict(new ApiResponse(409, StringConsts.EXISTED));

        //    Researcher researcher = _mapper.Map<Researcher>(model);
        //    Researcher oldResearcher = await _researcherRepository.GetAsync(model.Id).ConfigureAwait(true);
        //    researcher.PasswordHash = oldResearcher.PasswordHash;
        //    researcher.PasswordSalt = oldResearcher.PasswordSalt;

        //    _researcherRepository.Edit(researcher);
        //    await _unitOfWork.CompleteAsync().ConfigureAwait(true);

        //    ResearcherForGetDTO researcherDto = _mapper.Map<ResearcherForGetDTO>(researcher);
        //    return Ok(researcherDto);
        //}

        //[HttpPatch("{id}/ChangePassword")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<ResearcherForGetDTO>> ChangePassword(int id, ResearcherForChangePasswordDTO model)
        //{
        //    if (id != model.Id)
        //        return BadRequest(new ApiResponse(400, StringConcatenates.NotEqualIds(id, model.Id)));

        //    if (!await _researcherRepository.IsExist(id).ConfigureAwait(true))
        //        return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Researcher",id)));

        //    Researcher researcher = await _researcherRepository.GetAsync(model.Id).ConfigureAwait(true);
        //    SecurePassword.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
        //    researcher.PasswordHash = passwordHash;
        //    researcher.PasswordSalt = passwordSalt;
        //    researcher.IsRandomPassword = false;

        //    _researcherRepository.Edit(researcher);
        //    await _unitOfWork.CompleteAsync().ConfigureAwait(true);

        //    var claimsIdentity = Researcher.Identity as ClaimsIdentity;
        //    int researcherId = Convert.ToInt32(claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value);

        //    if (researcherId == id) return Ok(new TokenDTO { Token = _jwtManager.GenerateToken(researcher) });

        //    ResearcherForGetDTO researcherDto = _mapper.Map<ResearcherForGetDTO>(researcher);
        //    return Ok(researcherDto);
        //}

        //[HttpDelete("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<ResearcherForGetDTO>> Delete(int id)
        //{
        //    if (!await _researcherRepository.IsExist(id).ConfigureAwait(true))
        //        return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Researcher", id)));

        //    Researcher researcher = await _researcherRepository.GetAsync(id).ConfigureAwait(true);

        //    _researcherRepository.Remove(researcher);
        //    await _unitOfWork.CompleteAsync().ConfigureAwait(true);

        //    ResearcherForGetDTO researcherDto = _mapper.Map<ResearcherForGetDTO>(researcher);
        //    return Ok(researcherDto);
        //}

        //[HttpGet("{id:int}")]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<ResearcherForGetDTO>> Get(int id)
        //{
        //    if (!await _researcherRepository.IsExist(id).ConfigureAwait(true))
        //        return NotFound(new ApiResponse(404, StringConcatenates.NotExist("Researcher",id)));

        //    Researcher researcher = await _researcherRepository.GetAsync(id).ConfigureAwait(true);

        //    ResearcherForGetDTO researcherDto = _mapper.Map<ResearcherForGetDTO>(researcher);
        //    return Ok(researcherDto);
        //}

        //[HttpGet]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<IReadOnlyList<ResearcherForGetDTO>>> Get()
        //{
        //    List<ResearcherForGetDTO> researchers = _mapper.Map<List<ResearcherForGetDTO>>(await _researcherRepository.GetAsync().ConfigureAwait(true));
        //    return Ok(researchers);
        //}
    }
}