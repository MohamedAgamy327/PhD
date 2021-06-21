using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Core.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Enums;

namespace Core.Repository
{
    public class ResearchRepository : IResearchRepository
    {
        private readonly ApplicationContext _context;
        public ResearchRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Research> AddAsync(Research researcher)
        {
            await _context.Researchs.AddAsync(researcher);
            return researcher;
        }
        public Research Edit(Research researcher)
        {
            _context.Entry(researcher).State = EntityState.Modified;
            return researcher;
        }
        public async Task<Research> GetAsync(int id)
        {
            return await _context.Researchs.Include(d=>d.User).AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }
        public async Task<IEnumerable<Research>> GetAsync(SearchStatusEnum status)
        {
            return await _context.Researchs.Include(d=>d.User).Where(w => w.SearchStatus == status).OrderByDescending(o => o.Id).ToListAsync();
        }
        public async Task<IEnumerable<Research>> GetAsync()
        {
            return await _context.Researchs.Include(d => d.User).OrderByDescending(o => o.Id).ToListAsync();
        }
        public void Remove(Research researcher)
        {
            _context.Remove(researcher);
        }
        public async Task<bool> IsExist(int id)
        {
            return await _context.Researchs.AnyAsync(s => s.Id == id).ConfigureAwait(true);
        }
    }
}
