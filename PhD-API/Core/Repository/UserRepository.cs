using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Core.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.StaticHelpers;

namespace Core.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;
        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<User> AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
            return user;
        }
        public User Edit(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            return user;
        }
        public async Task<User> GetAsync(int id)
        {
            return await _context.Users.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<User>> GetAsync()
        {
            return await _context.Users.OrderByDescending(o => o.Id).ToListAsync();
        }
        public async Task<User> LoginAsync(string name, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

            if (user == null)
                return null;

            if (!SecurePassword.VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }
        public void Remove(User user)
        {
            _context.Remove(user);
        }
        public async Task<bool> IsExist(int id)
        {
            return await _context.Users.AnyAsync(s => s.Id == id).ConfigureAwait(true);
        }
        public async Task<bool> IsExist(string name)
        {
            return await _context.Users.AnyAsync(s => s.Name.ToLower() == name.ToLower()).ConfigureAwait(true);
        }
        public async Task<bool> IsExist(int id, string name)
        {
            return await _context.Users.AnyAsync(s => s.Id != id && s.Name.ToLower() == name.ToLower()).ConfigureAwait(true);
        }
    }
}
