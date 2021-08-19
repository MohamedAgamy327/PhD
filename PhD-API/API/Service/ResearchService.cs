using API.IService;
using Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace API.Service
{
    public class ResearchService : IResearchService
    {
        public string CreateAcceptMailTemplate(Research research, string token, string password, HttpRequest request)
        {
            string body = "Hi: " + research.Name + "<br/>";
            body += "Your research is accepted <br/>";
            body += "You can login by your credential info <br/>";
            body += "Your Email is: " + research.Email + "<br/>";
            body += "Your password is: " + password + "<br/>";
            body += " or by clicking  this link <br/>";
            body += $"<a href={request.Scheme}://{request.Host}{request.PathBase}/home?token={token} target='_blank'>Start From Here </a>" + "<br/>";
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
