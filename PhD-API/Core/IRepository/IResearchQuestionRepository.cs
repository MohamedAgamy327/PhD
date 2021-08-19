using Domain.Entities;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IResearchQuestionRepository
    {
        Task<ResearchQuestion> AddAsync(ResearchQuestion researchQuestion);
        void Remove(ResearchQuestion researchQuestion);
        Task<ResearchQuestion> GetAsync(int researchId, int questionId);
        Task<int> GetCountAsync(int researchId);
    }
}
