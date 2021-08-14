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
    public class AnswerRepository : IAnswerRepository
    {
        private readonly ApplicationContext _context;
        public AnswerRepository(ApplicationContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Answer>> GetAsync(QuestionTypeNum type)
        {
            return await _context.Answers.Include(q => q.Question).Where(w => w.Question.Type == type).OrderBy(o => o.Id).ToListAsync();
        }
    }
}
