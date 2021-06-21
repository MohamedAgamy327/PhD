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
        Task<IEnumerable<Research>> GetAsync(SearchStatusEnum status);
        Task<IEnumerable<Research>> GetAsync();
        Task<bool> IsExist(int id);
    }
}
