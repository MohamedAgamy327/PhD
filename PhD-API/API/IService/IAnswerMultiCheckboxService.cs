using System.Threading.Tasks;

namespace API.IService
{
    public interface IAnswerMultiCheckboxService
    {
        public Task AddInitAnswer(int researchId);
    }
}
