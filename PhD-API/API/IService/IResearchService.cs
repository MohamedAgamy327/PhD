using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace API.IService
{
    public interface IResearchService
    {
        public string CreateRegisterMailTemplate(string name);
        public string CreateAcceptMailTemplate(Research research, string token, string password, HttpRequest request);
        public string CreatePendingMailTemplate(string name);
        public string CreateRejectedMailTemplate(string name);
    }
}
