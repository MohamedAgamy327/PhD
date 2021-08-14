using API.IService;
using Microsoft.AspNetCore.Http;

namespace API.Service
{
    public class ResearchService : IResearchService
    {
        public string CreateAcceptMailTemplate(string name, string password, HttpRequest request)
        {
            string body = "Hi: " + name + "<br/>";
            body += "Your research is accepted <br/>";
            body += "Your password is: " + password + "<br/>";
            body += $"Get started from <a href={request.Scheme}://{request.Host}{request.PathBase}//login target='_blank'> Here </a>" + "<br/>";
            body += "Regards, " + "<br/>";
            body += "PhD managment system";
            return body;
        }

        public string CreatePendingMailTemplate(string name)
        {
            string body = "Hi: " + name + "<br/>";
            body += "We have received your research, which has been passed to our specialists for review / approval. One of our representatives will be in contact soon. <br/>";
            body += "Regards, " + "<br/>";
            body += "PhD managment system";
            return body;
        }

        public string CreateRegisterMailTemplate(string name)
        {
            string body = "Hi: " + name + "<br/>";
            body += "We have received your research, which has been passed to our specialists for review / approval. One of our representatives will be in contact soon. <br/>";
            body += "Regards, " + "<br/>";
            body += "PhD managment system";
            return body;
        }

        public string CreateRejectedMailTemplate(string name)
        {
            string body = "Hi: " + name + "<br/>";
            body += "Your research is rejected <br/>";
            body += "Regards, " + "<br/>";
            body += "PhD managment system";
            return body;
        }
    }
}
