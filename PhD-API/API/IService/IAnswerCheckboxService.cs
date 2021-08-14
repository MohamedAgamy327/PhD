using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace API.IService
{
    public interface IAnswerCheckboxService
    {
        public Task AddInitAnswer(int researchId);
    }
}
