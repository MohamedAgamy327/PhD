using System.Threading.Tasks;

namespace API.IService
{
    public interface IAnswerMultiPercentageService
    {
        public Task AddInitAnswer(int researchId);
    }
}
