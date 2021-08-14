using System.Collections.Generic;
using System.Threading.Tasks;
using API.DTO.Question;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Core.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    [Route("api/[controller]")]   
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IQuestionRepository _questionRepository;

        public QuestionsController( IMapper mapper ,IQuestionRepository questionRepository)
        {
            _mapper = mapper;
            _questionRepository = questionRepository;
        }


        [HttpGet]
        [Authorize(Roles = "Admin,Researcher")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IReadOnlyList<QuestionForGetDTO>>> Get()
        {
            List<QuestionForGetDTO> questions = _mapper.Map<List<QuestionForGetDTO>>(await _questionRepository.GetAsync().ConfigureAwait(true));
            return Ok(questions);
        }
    }
}