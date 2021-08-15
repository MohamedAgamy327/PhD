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
    public class AnswerMultiPercentageService : IAnswerMultiPercentageService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerMultiPercentageRepository _answerMultiPercentageRepository;
        private readonly IAnswerRepository _answerRepository;
        public AnswerMultiPercentageService(IUnitOfWork unitOfWork, IAnswerMultiPercentageRepository answerMultiPercentageRepository, IAnswerRepository answerRepository)
        {
            _unitOfWork = unitOfWork;
            _answerMultiPercentageRepository = answerMultiPercentageRepository;
            _answerRepository = answerRepository;
        }

        public async Task AddInitAnswer(int researchId)
        {
            IEnumerable<Answer> answers = await _answerRepository.GetAsync(QuestionTypeNum.MultiPercentage).ConfigureAwait(true);
            IEnumerable<AnswerMultiPercentage> answerMultiPercentages = await _answerMultiPercentageRepository.GetByResearchAsync(researchId).ConfigureAwait(true);

            foreach (var answer in answers)
            {
                if (!answerMultiPercentages.Any(d => d.AnswerId == answer.Id))
                    await _answerMultiPercentageRepository.AddAsync(new AnswerMultiPercentage
                    {
                        QuestionId = answer.QuestionId,
                        AnswerId = answer.Id,
                        ResearchId = researchId
                    }).ConfigureAwait(true);
            }

            await _unitOfWork.CompleteAsync().ConfigureAwait(true);
        }
    }
}
