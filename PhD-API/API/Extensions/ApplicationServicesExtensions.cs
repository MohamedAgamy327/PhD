using API.Helpers;
using API.IHelpers;
using Microsoft.Extensions.DependencyInjection;
using Core.IRepository;
using Core.Repository;
using Core.UnitOfWork;
using API.Service;
using API.IService;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();       
            services.AddScoped<IUserRepository, UserRepository>();                                  
            services.AddScoped<IQuestionRepository, QuestionRepository>();                 
            services.AddScoped<IResearchRepository, ResearchRepository>();
            services.AddScoped<IAnswerRadioRepository, AnswerRadioRepository>();

            services.AddTransient<IJWTManager, JWTManager>();
            services.AddTransient<IResearchService, ResearchService>();
            return services;
        }
    }
}
