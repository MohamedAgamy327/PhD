using API.IService;
using Core.IRepository;
using Core.UnitOfWork;
using Domain.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Service
{
    public class ResearchQuestionService : IResearchQuestionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IResearchQuestionRepository _researchQuestionRepository;
        private readonly IQuestionRepository _questionRepository;
        public ResearchQuestionService(IUnitOfWork unitOfWork, IResearchQuestionRepository researchQuestionRepository, IQuestionRepository questionRepository)
        {
            _unitOfWork = unitOfWork;
            _researchQuestionRepository = researchQuestionRepository;
            _questionRepository = questionRepository;
        }

        public async Task AddInitResearchQuestions(int researchId)
        {
            IEnumerable<Question> questions = await _questionRepository.GetAsync().ConfigureAwait(true);
            IEnumerable<ResearchQuestion> researchQuestions = await _researchQuestionRepository.GetByResearchAsync(researchId).ConfigureAwait(true);

            foreach (var question in questions)
            {
                if (!researchQuestions.Any(d => d.QuestionId == question.Id))
                    await _researchQuestionRepository.AddAsync(new ResearchQuestion
                    {
                        QuestionId = question.Id,
                        ResearchId = researchId
                    }).ConfigureAwait(true);
            }

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);
        }
    }
}
