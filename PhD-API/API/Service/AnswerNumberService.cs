using API.IService;
using Core.IRepository;
using Core.UnitOfWork;
using Domain.Entities;
using Domain.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service
{
    public class AnswerNumberService : IAnswerNumberService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerNumberRepository _answerNumberRepository;
        private readonly IQuestionRepository _questionRepository;
      
        public AnswerNumberService(IUnitOfWork unitOfWork, IAnswerNumberRepository answerNumberRepository, IQuestionRepository questionRepository)
        {
            _unitOfWork = unitOfWork;
            _answerNumberRepository = answerNumberRepository;
            _questionRepository = questionRepository;
        }

        public async Task AddInitAnswer(int researchId)
        {
            IEnumerable<Question> questions = await _questionRepository.GetAsync(QuestionTypeNum.Number).ConfigureAwait(true);
            IEnumerable<AnswerNumber> answerNumbers = await _answerNumberRepository.GetByResearchAsync(researchId).ConfigureAwait(true);

            foreach (var question in questions)
            {
                if (!answerNumbers.Any(d => d.QuestionId == question.Id))
                    await _answerNumberRepository.AddAsync(new AnswerNumber
                    {
                        QuestionId = question.Id,
                        ResearchId = researchId
                    }).ConfigureAwait(true);
            }

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);
        }
    }
}
