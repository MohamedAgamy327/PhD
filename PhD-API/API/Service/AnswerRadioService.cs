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
    public class AnswerRadioService : IAnswerRadioService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerRadioRepository _answerRadioRepository;
        private readonly IQuestionRepository _questionRepository;
        public AnswerRadioService(IUnitOfWork unitOfWork, IAnswerRadioRepository answerRadioRepository, IQuestionRepository questionRepository)
        {
            _unitOfWork = unitOfWork;
            _answerRadioRepository = answerRadioRepository;
            _questionRepository = questionRepository;
        }

        public async Task AddInitAnswer(int researchId)
        {
            IEnumerable<Question> questions = await _questionRepository.GetAsync(QuestionTypeNum.Radio).ConfigureAwait(true);
            IEnumerable<AnswerRadio> answerRadios = await _answerRadioRepository.GetByResearchAsync(researchId).ConfigureAwait(true);

            foreach (var question in questions)
            {
                if (!answerRadios.Any(d => d.QuestionId == question.Id))
                    await _answerRadioRepository.AddAsync(new AnswerRadio
                    {
                        QuestionId = question.Id,
                        ResearchId = researchId
                    }).ConfigureAwait(true);
            }

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);
        }
    }
}
