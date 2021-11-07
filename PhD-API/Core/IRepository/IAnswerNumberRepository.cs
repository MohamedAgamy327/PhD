using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IAnswerNumberRepository
    {
        Task<AnswerNumber> AddAsync(AnswerNumber answerNumber);
        AnswerNumber Edit(AnswerNumber answerNumber);
        Task<AnswerNumber> GetAsync(int id);
        Task<AnswerNumber> GetAsync(int researchId, int questionId);
        Task<IEnumerable<AnswerNumber>> GetByResearchAsync(int researchId);
        Task<bool> IsExist(int id);
    }
}
