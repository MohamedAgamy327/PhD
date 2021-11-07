using Core.IRepository;
using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class AnswerCheckboxRepository : IAnswerCheckboxRepository
    {
        private readonly ApplicationContext _context;
        public AnswerCheckboxRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<AnswerCheckbox> AddAsync(AnswerCheckbox answerCheckbox)
        {
            await _context.AnswerCheckboxs.AddAsync(answerCheckbox);
            return answerCheckbox;
        }

        public AnswerCheckbox Edit(AnswerCheckbox answerCheckbox)
        {
            _context.Entry(answerCheckbox).State = EntityState.Modified;
            return answerCheckbox;
        }

        public async Task<AnswerCheckbox> GetAsync(int id)
        {
            return await _context.AnswerCheckboxs.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<AnswerCheckbox>> GetAsync()
        {
            return await _context.AnswerCheckboxs.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<AnswerCheckbox>> GetByResearchAsync(int researchId)
        {
            return await _context.AnswerCheckboxs.Where(s => s.ResearchId == researchId).AsNoTracking().ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.AnswerCheckboxs.AnyAsync(s => s.Id == id).ConfigureAwait(true);
        }
    }
}
