using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace API.IService
{
    public interface IAnswerRadioService
    {
        public Task AddInitAnswer(int researchId);
    }
}
