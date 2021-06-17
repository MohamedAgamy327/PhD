using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IUserRepository
    {
        Task<User> AddAsync(User user);
        User Edit(User user);
        void Remove(User user);
        Task<User> LoginAsync(string username, string password);
        Task<User> GetAsync(int id);
        Task<IEnumerable<User>> GetAsync();
        Task<bool> IsExist(int id);
        Task<bool> IsExist(string name);
        Task<bool> IsExist(int id, string name);
    }
}
