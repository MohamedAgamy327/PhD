using Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.IRepository
{
    public interface IQuestionRepository
    {
        Task<IEnumerable<Question>> GetAsync();
    }
}
