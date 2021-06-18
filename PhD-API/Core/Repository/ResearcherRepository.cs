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
    public class ResearcherRepository : IResearcherRepository
    {
        private readonly ApplicationContext _context;
        public ResearcherRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Researcher> AddAsync(Researcher researcher)
        {
            await _context.Researchers.AddAsync(researcher);
            return researcher;
        }
        public Researcher Edit(Researcher researcher)
        {
            _context.Entry(researcher).State = EntityState.Modified;
            return researcher;
        }
        public async Task<Researcher> GetAsync(int id)
        {
            return await _context.Researchers.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Researcher>> GetAsync(SearchStatusEnum status)
        {
            return await _context.Researchers.Where(w => w.SearchStatus == status).OrderByDescending(o => o.Id).ToListAsync();
        }
        public async Task<Researcher> LoginAsync(string email, string password)
        {
            var researcher = await _context.Researchers.FirstOrDefaultAsync(x => x.Email.ToLower() == email.ToLower());

            if (researcher == null)
                return null;

            if (!SecurePassword.VerifyPasswordHash(password, researcher.PasswordHash, researcher.PasswordSalt))
                return null;

            return researcher;
        }
        public void Remove(Researcher researcher)
        {
            _context.Remove(researcher);
        }
        public async Task<bool> IsExist(int id)
        {
            return await _context.Researchers.AnyAsync(s => s.Id == id).ConfigureAwait(true);
        }
        public async Task<bool> IsExist(string email)
        {
            return await _context.Researchers.AnyAsync(s => s.Email.ToLower() == email.ToLower()).ConfigureAwait(true);
        }
        public async Task<bool> IsExist(int id, string email)
        {
            return await _context.Researchers.AnyAsync(s => s.Id != id && s.Email.ToLower() == email.ToLower()).ConfigureAwait(true);
        }
    }
}
