using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IAnswerMultiPercentageRepository
    {
        Task<AnswerMultiPercentage> AddAsync(AnswerMultiPercentage answerMultiPercentage);
        AnswerMultiPercentage Edit(AnswerMultiPercentage answerMultiPercentage);
        Task<AnswerMultiPercentage> GetAsync(int id);
        Task<IEnumerable<AnswerMultiPercentage>> GetByResearchAsync(int researchId);
        Task<bool> IsExist(int id);
    }
}
