using Core.IRepository;
using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class AnswerNumberRepository : IAnswerNumberRepository
    {
        private readonly ApplicationContext _context;
        public AnswerNumberRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<AnswerNumber> AddAsync(AnswerNumber answerNumber)
        {
            await _context.AnswerNumbers.AddAsync(answerNumber);
            return answerNumber;
        }

        public AnswerNumber Edit(AnswerNumber answerNumber)
        {
            _context.Entry(answerNumber).State = EntityState.Modified;
            return answerNumber;
        }

        public async Task<AnswerNumber> GetAsync(int id)
        {
            return await _context.AnswerNumbers.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<AnswerNumber>> GetByResearchAsync(int researchId)
        {
            return await _context.AnswerNumbers.Where(s => s.ResearchId == researchId).AsNoTracking().ToListAsync();
        }

        public async Task<bool> IsExist(int id)
        {
            return await _context.AnswerNumbers.AnyAsync(s => s.Id == id).ConfigureAwait(true);
        }
    }
}
