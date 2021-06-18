using Domain.Entities;
using Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IResearcherRepository
    {
        Task<Researcher> AddAsync(Researcher researcher);
        Researcher Edit(Researcher researcher);
        void Remove(Researcher researcher);
        Task<Researcher> LoginAsync(string email, string password);
        Task<Researcher> GetAsync(int id);
        Task<IEnumerable<Researcher>> GetAsync(SearchStatusEnum status);
        Task<bool> IsExist(int id);
        Task<bool> IsExist(string email);
        Task<bool> IsExist(int id, string email);
    }
}
