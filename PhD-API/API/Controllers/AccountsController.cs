using API.DTO.Account;
using API.Errors;
using API.IHelpers;
using Core.IRepository;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Utilities.StaticHelpers;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly IJWTManager _jwtManager;
        private readonly IUserRepository _userRepository;
        private readonly IResearchRepository _researchRepository;

        public AccountsController(IJWTManager jwtManager, IUserRepository userRepository, IResearchRepository researchRepository)
        {
            _jwtManager = jwtManager;
            _userRepository = userRepository;
            _researchRepository = researchRepository;
        }

        [HttpPost("user/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TokenDTO>> UserLogin(LoginDTO model)
        {
            User user = await _userRepository.LoginAsync(model.Email, model.Password).ConfigureAwait(true);

            if (user == null)
                return Unauthorized(new ApiResponse(401, StringConsts.UNAUTHORIZED));

            return Ok(new TokenDTO { Token = _jwtManager.GenerateToken(user) });
        }

        [HttpPost("research/login")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<TokenDTO>> ResearchLogin(LoginDTO model)
        {
            Research research = await _researchRepository.LoginAsync(model.Email, model.Password).ConfigureAwait(true);

            if (research == null)
                return Unauthorized(new ApiResponse(401, StringConsts.UNAUTHORIZED));

            return Ok(new TokenDTO { Token = _jwtManager.GenerateToken(research) });
        }

    }
}
