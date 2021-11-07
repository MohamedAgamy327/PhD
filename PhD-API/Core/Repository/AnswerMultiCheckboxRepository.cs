using Core.IRepository;
using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class AnswerMultiCheckboxRepository : IAnswerMultiCheckboxRepository
    {
        private readonly ApplicationContext _context;
        public AnswerMultiCheckboxRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<AnswerMultiCheckbox> AddAsync(AnswerMultiCheckbox answerMultiCheckbox)
        {
            await _context.AnswerMultiCheckboxs.AddAsync(answerMultiCheckbox);
            return answerMultiCheckbox;
        }

        public AnswerMultiCheckbox Edit(AnswerMultiCheckbox answerMultiCheckbox)
        {
            _context.Entry(answerMultiCheckbox).State = EntityState.Modified;
            return answerMultiCheckbox;
        }

        public async Task<AnswerMultiCheckbox> GetAsync(int id)
        {
            return await _context.AnswerMultiCheckboxs.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<AnswerMultiCheckbox>> GetByResearchAsync(int researchId)
        {
            return await _context.AnswerMultiCheckboxs.Where(s => s.ResearchId == researchId).AsNoTracking().ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.AnswerMultiCheckboxs.AnyAsync(s => s.Id == id).ConfigureAwait(true);
        }

        public async Task<IEnumerable<AnswerMultiCheckbox>> GetAsync()
        {
            return await _context.AnswerMultiCheckboxs.AsNoTracking().ToListAsync();
        }
    }
}
