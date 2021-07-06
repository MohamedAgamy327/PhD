using Domain.Entities;
using Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IResearchRepository
    {
        Task<Research> AddAsync(Research researcher);
        Research Edit(Research researcher);
        void Remove(Research researcher);
        Task<Research> GetAsync(int id);
        Task<Research> LoginAsync(string email, string password);
        Task<IEnumerable<Research>> GetAsync(ResearchStatusEnum status);
        Task<IEnumerable<Research>> GetAsync();
        Task<bool> IsExist(int id);
        Task<bool> IsExist(string email);
    }
}
