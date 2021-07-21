using API.Helpers;
using API.IHelpers;
using Microsoft.Extensions.DependencyInjection;
using Core.IRepository;
using Core.Repository;
using Core.UnitOfWork;

namespace API.Extensions
{
    public static class ApplicationServicesExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IJWTManager, JWTManager>();
            services.AddScoped<IUserRepository, UserRepository>();                 
            services.AddScoped<IQuestionRepository, QuestionRepository>();                 
            services.AddScoped<IResearchRepository, ResearchRepository>();                 
            return services;
        }
    }
}
