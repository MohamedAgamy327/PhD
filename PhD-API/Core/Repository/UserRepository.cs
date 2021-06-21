using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Core.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.StaticHelpers;
using Domain.Enums;

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
            return await _context.Users.Where(w => w.Role == RoleEnum.Admin).OrderByDescending(o => o.Id).ToListAsync();
        }
        public async Task<User> LoginAsync(string email, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());

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
        public async Task<bool> IsExist(string email)
        {
            return await _context.Users.AnyAsync(s => s.Email.ToLower() == email.ToLower()).ConfigureAwait(true);
        }
        public async Task<bool> IsExist(int id, string email)
        {
            return await _context.Users.AnyAsync(s => s.Id != id && s.Email.ToLower() == email.ToLower()).ConfigureAwait(true);
        }
    }
}
