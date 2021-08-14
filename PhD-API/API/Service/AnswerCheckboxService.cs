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
    public class AnswerCheckboxService : IAnswerCheckboxService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAnswerCheckboxRepository _answerCheckboxRepository;
        private readonly IAnswerRepository _answerRepository;
        public AnswerCheckboxService(IUnitOfWork unitOfWork, IAnswerCheckboxRepository answerCheckboxRepository,  IAnswerRepository answerRepository)
        {
            _unitOfWork = unitOfWork;
            _answerCheckboxRepository = answerCheckboxRepository;
            _answerRepository = answerRepository;
        }

        public async Task AddInitAnswer(int researchId)
        {
            IEnumerable<Answer> answers = await _answerRepository.GetAsync(QuestionTypeNum.Checkbox).ConfigureAwait(true);
            IEnumerable<AnswerCheckbox> answerCheckboxs = await _answerCheckboxRepository.GetByResearchAsync(researchId).ConfigureAwait(true);

            foreach (var answer in answers)
            {
                if (!answerCheckboxs.Any(d => d.AnswerId == answer.Id))
                    await _answerCheckboxRepository.AddAsync(new AnswerCheckbox
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
