using Domain.Entities;
using Domain.Enums;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IAnswerRepository
    {
        Task<IEnumerable<Answer>> GetAsync(QuestionTypeNum type);
    }
}
