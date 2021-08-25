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
using Domain.Enums;

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
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<QuestionForGetDTO>>> Get()
        {     
            List<QuestionForGetDTO> questions = _mapper.Map<List<QuestionForGetDTO>>(await _questionRepository.GetAsync().ConfigureAwait(true));
            return Ok(questions);
        }

        //[HttpGet("count/{id:int}")]
        //[Authorize]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //public async Task<ActionResult<IReadOnlyList<QuestionForGetDTO>>> Get(int? id)
        //{
        //    var claimsIdentity = User.Identity as ClaimsIdentity;
        //    string role = claimsIdentity.Claims.Where(c => c.Type == ClaimTypes.Role).FirstOrDefault()?.Value;

        //    if (role == RoleEnum.Admin.ToString())
        //    {
        //    }
        //    else
        //    {
        //        string researchId = claimsIdentity.Claims.Where(c => c.Type == "id").FirstOrDefault()?.Value;
        //        return Ok()
        //    }

          
        //    //return Ok( new {Questions= questions, count= await _researchQuestionRepository.GetCountAsync(Convert.ToInt32(researchId)) });

        //    return Ok(questions);
        //}
    }
}