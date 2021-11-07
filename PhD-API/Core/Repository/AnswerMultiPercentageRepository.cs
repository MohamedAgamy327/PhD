using Core.IRepository;
using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class AnswerMultiPercentageRepository : IAnswerMultiPercentageRepository
    {
        private readonly ApplicationContext _context;
        public AnswerMultiPercentageRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<AnswerMultiPercentage> AddAsync(AnswerMultiPercentage answerMultiPercentage)
        {
            await _context.AnswerMultiPercentages.AddAsync(answerMultiPercentage);
            return answerMultiPercentage;
        }

        public AnswerMultiPercentage Edit(AnswerMultiPercentage answerMultiPercentage)
        {
            _context.Entry(answerMultiPercentage).State = EntityState.Modified;
            return answerMultiPercentage;
        }

        public async Task<AnswerMultiPercentage> GetAsync(int id)
        {
            return await _context.AnswerMultiPercentages.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<AnswerMultiPercentage>> GetAsync()
        {
            return await _context.AnswerMultiPercentages.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<AnswerMultiPercentage>> GetByResearchAsync(int researchId)
        {
            return await _context.AnswerMultiPercentages.Where(s => s.ResearchId == researchId).AsNoTracking().ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.AnswerMultiPercentages.AnyAsync(s => s.Id == id).ConfigureAwait(true);
        }
    }
}
