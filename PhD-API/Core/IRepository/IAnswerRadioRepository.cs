using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IAnswerRadioRepository
    {
        Task<AnswerRadio> AddAsync(AnswerRadio answerRadio);
        AnswerRadio Edit(AnswerRadio answerRadio);
        Task<AnswerRadio> GetAsync(int id);
        Task<IEnumerable<AnswerRadio>> GetByResearchAsync(int researchId);
    }
}
