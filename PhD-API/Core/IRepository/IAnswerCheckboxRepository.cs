using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IAnswerCheckboxRepository
    {
        Task<AnswerCheckbox> AddAsync(AnswerCheckbox answerCheckbox);
        AnswerCheckbox Edit(AnswerCheckbox answerCheckbox);
        Task<AnswerCheckbox> GetAsync(int id);
        Task<IEnumerable<AnswerCheckbox>> GetByResearchAsync(int researchId);
        Task<IEnumerable<AnswerCheckbox>> GetAsync();
        Task<bool> IsExist(int id);
    }
}
