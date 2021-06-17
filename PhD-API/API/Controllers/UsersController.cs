using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.User;
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
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IJWTManager _jwtManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        public UsersController(IJWTManager jwtManager, IMapper mapper, IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _mapper = mapper;
            _jwtManager = jwtManager;
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserForGetDTO>> Post(UserForAddDTO model)
        {
            if (await _userRepository.IsExist(model.Name).ConfigureAwait(true))
                return Conflict(new ApiResponse(409, StringConsts.EXISTED));

            User user = _mapper.Map<User>(model);
            SecurePassword.CreatePasswordHash("123123", out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _userRepository.AddAsync(user).ConfigureAwait(true);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            UserForGetDTO userDto = _mapper.Map<UserForGetDTO>(user);
            return Ok(userDto);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserForGetDTO>> Put(int id, UserForEditDTO model)
        {
            if (id != model.Id)
                return BadRequest(new ApiResponse(400, StringConcatenates.NotEqualIds(id, model.Id)));

            if (!await _userRepository.IsExist(id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("User",id)));

            if (await _userRepository.IsExist(model.Id, model.Name).ConfigureAwait(true))
                return Conflict(new ApiResponse(409, StringConsts.EXISTED));

            User user = _mapper.Map<User>(model);
            User oldUser = await _userRepository.GetAsync(model.Id).ConfigureAwait(true);
            user.PasswordHash = oldUser.PasswordHash;
            user.PasswordSalt = oldUser.PasswordSalt;

            _userRepository.Edit(user);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            UserForGetDTO userDto = _mapper.Map<UserForGetDTO>(user);
            return Ok(userDto);
        }

        [HttpPatch("{id}/ChangePassword")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserForGetDTO>> ChangePassword(int id, UserForChangePasswordDTO model)
        {
            if (id != model.Id)
                return BadRequest(new ApiResponse(400, StringConcatenates.NotEqualIds(id, model.Id)));

            if (!await _userRepository.IsExist(id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("User",id)));

            User user = await _userRepository.GetAsync(model.Id).ConfigureAwait(true);
            SecurePassword.CreatePasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
            user.IsRandomPassword = false;

            _userRepository.Edit(user);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            var claimsIdentity = User.Identity as ClaimsIdentity;
            int userId = Convert.ToInt32(claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value);

            if (userId == id) return Ok(new TokenDTO { Token = _jwtManager.GenerateToken(user) });

            UserForGetDTO userDto = _mapper.Map<UserForGetDTO>(user);
            return Ok(userDto);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserForGetDTO>> Delete(int id)
        {
            if (!await _userRepository.IsExist(id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("User", id)));

            User user = await _userRepository.GetAsync(id).ConfigureAwait(true);

            _userRepository.Remove(user);
            await _unitOfWork.CompleteAsync().ConfigureAwait(true);

            UserForGetDTO userDto = _mapper.Map<UserForGetDTO>(user);
            return Ok(userDto);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<UserForGetDTO>> Get(int id)
        {
            if (!await _userRepository.IsExist(id).ConfigureAwait(true))
                return NotFound(new ApiResponse(404, StringConcatenates.NotExist("User",id)));

            User user = await _userRepository.GetAsync(id).ConfigureAwait(true);

            UserForGetDTO userDto = _mapper.Map<UserForGetDTO>(user);
            return Ok(userDto);
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<UserForGetDTO>>> Get()
        {
            List<UserForGetDTO> users = _mapper.Map<List<UserForGetDTO>>(await _userRepository.GetAsync().ConfigureAwait(true));
            return Ok(users);
        }
    }
}