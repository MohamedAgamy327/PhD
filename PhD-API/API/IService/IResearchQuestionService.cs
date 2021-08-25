using System.Threading.Tasks;

namespace API.IService
{
    public interface IResearchQuestionService
    {
        public Task AddInitResearchQuestions(int researchId);
    }
}
