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
    public class AnswerMultiCheckboxService : IAnswerMultiCheckboxService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerMultiCheckboxRepository _answerMultiCheckboxRepository;
        private readonly IAnswerRepository _answerRepository;
        public AnswerMultiCheckboxService(IUnitOfWork unitOfWork, IAnswerMultiCheckboxRepository answerMultiCheckboxRepository, IAnswerRepository answerRepository)
        {
            _unitOfWork = unitOfWork;
            _answerMultiCheckboxRepository = answerMultiCheckboxRepository;
            _answerRepository = answerRepository;
        }

        public async Task AddInitAnswer(int researchId)
        {
            IEnumerable<Answer> answers = await _answerRepository.GetAsync(QuestionTypeNum.MultiCheckbox).ConfigureAwait(true);
            IEnumerable<AnswerMultiCheckbox> answerMultiCheckboxs = await _answerMultiCheckboxRepository.GetByResearchAsync(researchId).ConfigureAwait(true);

            foreach (var answer in answers)
            {
                if (!answerMultiCheckboxs.Any(d => d.AnswerId == answer.Id))
                    await _answerMultiCheckboxRepository.AddAsync(new AnswerMultiCheckbox
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
