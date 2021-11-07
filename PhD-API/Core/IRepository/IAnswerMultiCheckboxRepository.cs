using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IAnswerMultiCheckboxRepository
    {
        Task<AnswerMultiCheckbox> AddAsync(AnswerMultiCheckbox answerMultiCheckbox);
        AnswerMultiCheckbox Edit(AnswerMultiCheckbox answerMultiCheckbox);
        Task<AnswerMultiCheckbox> GetAsync(int id);
        Task<IEnumerable<AnswerMultiCheckbox>> GetByResearchAsync(int researchId);
        Task<bool> IsExist(int id);
        Task<IEnumerable<AnswerMultiCheckbox>> GetAsync();
    }
}
