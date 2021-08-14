using Core.IRepository;
using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class AnswerRadioRepository : IAnswerRadioRepository
    {
        private readonly ApplicationContext _context;
        public AnswerRadioRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<AnswerRadio> AddAsync(AnswerRadio answerRadio)
        {
            await _context.AnswerRadios.AddAsync(answerRadio);
            return answerRadio;
        }

        public AnswerRadio Edit(AnswerRadio answerRadio)
        {
            _context.Entry(answerRadio).State = EntityState.Modified;
            return answerRadio;
        }

        public async Task<AnswerRadio> GetAsync(int id)
        {
            return await _context.AnswerRadios.AsNoTracking().SingleOrDefaultAsync(s => s.Id == id);
        }

        public async Task<IEnumerable<AnswerRadio>> GetByResearchAsync(int researchId)
        {
            return await _context.AnswerRadios.Where(s => s.ResearchId == researchId).AsNoTracking().ToListAsync();
        }
    }
}
