using System.Threading.Tasks;

namespace API.IService
{
    public interface IAnswerNumberService
    {
        public Task AddInitAnswer(int researchId);
    }
}
