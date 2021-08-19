using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Question;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Core.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using System.Linq;
using System;

namespace API.Controllers
{
    [Route("api/[controller]")]   
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;
        private readonly IResearchQuestionRepository _researchQuestionRepository;

        public QuestionsController(IMapper mapper, IQuestionRepository questionRepository, IResearchQuestionRepository researchQuestionRepository)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
            _researchQuestionRepository = researchQuestionRepository;
        }


        [HttpGet]
        [Authorize(Roles = "Admin,Researcher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<QuestionForGetDTO>>> Get()
        {
            var claimsIdentity = User.Identity as ClaimsIdentity;
            string userId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;
            List<QuestionForGetDTO> questions = _mapper.Map<List<QuestionForGetDTO>>(await _questionRepository.GetAsync().ConfigureAwait(true));
            return Ok( new {Questions= questions, count= await _researchQuestionRepository.GetCountAsync(Convert.ToInt32(userId)) });
        }
    }
}