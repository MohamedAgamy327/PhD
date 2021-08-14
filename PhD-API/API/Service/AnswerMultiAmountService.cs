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
    public class AnswerMultiAmountService : IAnswerMultiAmountService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerMultiAmountRepository _answerMultiAmountRepository;
        private readonly IAnswerRepository _answerRepository;
        public AnswerMultiAmountService(IUnitOfWork unitOfWork, IAnswerMultiAmountRepository answerMultiAmountRepository,  IAnswerRepository answerRepository)
        {
            _unitOfWork = unitOfWork;
            _answerMultiAmountRepository = answerMultiAmountRepository;
            _answerRepository = answerRepository;
        }

        public async Task AddInitAnswer(int researchId)
        {
            IEnumerable<Answer> answers = await _answerRepository.GetAsync(QuestionTypeNum.MultiAmount).ConfigureAwait(true);
            IEnumerable<AnswerMultiAmount> answerMultiAmounts = await _answerMultiAmountRepository.GetByResearchAsync(researchId).ConfigureAwait(true);

            foreach (var answer in answers)
            {
                if (!answerMultiAmounts.Any(d => d.AnswerId == answer.Id))
                    await _answerMultiAmountRepository.AddAsync(new AnswerMultiAmount
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
