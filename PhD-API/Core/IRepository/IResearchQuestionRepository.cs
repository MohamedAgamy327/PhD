using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IResearchQuestionRepository
    {
        Task<ResearchQuestion> AddAsync(ResearchQuestion researchQuestion);
        Task<IEnumerable<ResearchQuestion>> AddRangeAsync(ICollection<ResearchQuestion> researchQuestions);
        ResearchQuestion Edit(ResearchQuestion researchQuestion);
        void Remove(ResearchQuestion researchQuestion);
        Task<ResearchQuestion> GetAsync(int researchId, int questionId);
        Task<IEnumerable<ResearchQuestion>> GetByResearchAsync(int researchId);
        Task<int> GetCountAsync(int researchId);
    }
}
