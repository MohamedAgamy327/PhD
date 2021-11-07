using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IAnswerMultiAmountRepository
    {
        Task<AnswerMultiAmount> AddAsync(AnswerMultiAmount answerMultiAmount);
        AnswerMultiAmount Edit(AnswerMultiAmount answerMultiAmount);
        Task<AnswerMultiAmount> GetAsync(int id);
        Task<IEnumerable<AnswerMultiAmount>> GetByResearchAsync(int researchId);
        Task<IEnumerable<AnswerMultiAmount>> GetAsync();
        Task<bool> IsExist(int id);
    }
}
