using Core.IRepository;
using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class AnswerMultiAmountRepository : IAnswerMultiAmountRepository
    {
        private readonly ApplicationContext _context;
        public AnswerMultiAmountRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<AnswerMultiAmount> AddAsync(AnswerMultiAmount answerMultiAmount)
        {
            await _context.AnswerMultiAmounts.AddAsync(answerMultiAmount);
            return answerMultiAmount;
        }

        public AnswerMultiAmount Edit(AnswerMultiAmount answerMultiAmount)
        {
            _context.Entry(answerMultiAmount).State = EntityState.Modified;
            return answerMultiAmount;
        }

        public async Task<AnswerMultiAmount> GetAsync(int id)
        {
            return await _context.AnswerMultiAmounts.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<AnswerMultiAmount>> GetByResearchAsync(int researchId)
        {
            return await _context.AnswerMultiAmounts.Where(s => s.ResearchId == researchId).AsNoTracking().ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.AnswerMultiAmounts.AnyAsync(s => s.Id == id).ConfigureAwait(true);
        }
    }
}
