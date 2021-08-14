using Domain.Entities;
using Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAsync();
        Task<IEnumerable<Question>> GetAsync(QuestionTypeNum type);
    }
}
