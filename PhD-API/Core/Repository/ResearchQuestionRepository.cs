using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Core.IRepository;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Core.Repository
{
    public class ResearchQuestionRepository : IResearchQuestionRepository
    {
        private readonly ApplicationContext _context;
        public ResearchQuestionRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<ResearchQuestion> AddAsync(ResearchQuestion researchQuestion)
        {
            await _context.ResearchsQuestions.AddAsync(researchQuestion);
            return researchQuestion;
        }
        public async Task<ResearchQuestion> GetAsync(int researchId, int questionId)
        {
            return await _context.ResearchsQuestions.AsNoTracking().SingleOrDefaultAsync(s => s.ResearchId == researchId && s.QuestionId == questionId);
        }
        public void Remove(ResearchQuestion researchQuestion)
        {
            _context.Remove(researchQuestion);
        }
        public async Task<int> GetCountAsync(int researchId)
        {
            return await _context.ResearchsQuestions.Where(w => w.ResearchId == researchId && w.Answered == true).CountAsync().ConfigureAwait(true);
        }
        public async Task<IEnumerable<ResearchQuestion>> AddRangeAsync(ICollection<ResearchQuestion> researchQuestions)
        {
            await _context.ResearchsQuestions.AddRangeAsync(researchQuestions);
            return researchQuestions;
        }
        public ResearchQuestion Edit(ResearchQuestion researchQuestion)
        {
            _context.Entry(researchQuestion).State = EntityState.Modified;
            return researchQuestion;
        }

        public async Task<IEnumerable<ResearchQuestion>> GetByResearchAsync(int researchId)
        {
            return await _context.ResearchsQuestions.Where(s => s.ResearchId == researchId).AsNoTracking().ToListAsync();
        }
    }
}
