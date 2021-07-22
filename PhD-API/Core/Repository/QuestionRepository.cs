using Data.Context;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Core.IRepository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Repository
{
    public class QuestionRepository : IQuestionRepository
    {
        private readonly ApplicationContext _context;
        public QuestionRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Question>> GetAsync()
        {
            return await _context.Questions.Include(d => d.Answers).OrderBy(o => o.Order).ToListAsync();
        }
    }
}
