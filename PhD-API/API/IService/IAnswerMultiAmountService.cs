using System.Threading.Tasks;

namespace API.IService
{
    public interface IAnswerMultiAmountService
    {
        public Task AddInitAnswer(int researchId);
    }
}
