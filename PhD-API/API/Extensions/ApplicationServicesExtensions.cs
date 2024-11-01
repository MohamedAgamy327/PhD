﻿using API.Helpers;
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
            services.AddScoped<IAnswerRepository, AnswerRepository>();
            services.AddScoped<IAnswerRadioRepository, AnswerRadioRepository>();
            services.AddScoped<IAnswerNumberRepository, AnswerNumberRepository>();
            services.AddScoped<IAnswerCheckboxRepository, AnswerCheckboxRepository>();
            services.AddScoped<IAnswerMultiAmountRepository, AnswerMultiAmountRepository>();
            services.AddScoped<IAnswerMultiPercentageRepository, AnswerMultiPercentageRepository>();
            services.AddScoped<IAnswerMultiCheckboxRepository, AnswerMultiCheckboxRepository>();
            services.AddScoped<IResearchQuestionRepository, ResearchQuestionRepository>();

            services.AddTransient<IJWTManager, JWTManager>();
            services.AddTransient<IResearchService, ResearchService>();
            services.AddTransient<IAnswerRadioService, AnswerRadioService>();
            services.AddTransient<IAnswerNumberService, AnswerNumberService>();
            services.AddTransient<IAnswerCheckboxService, AnswerCheckboxService>();
            services.AddTransient<IResearchQuestionService, ResearchQuestionService>();
            services.AddTransient<IAnswerMultiAmountService, AnswerMultiAmountService>();           
            services.AddTransient<IAnswerMultiCheckboxService, AnswerMultiCheckboxService>();
            services.AddTransient<IAnswerMultiCheckboxService, AnswerMultiCheckboxService>();        
            services.AddTransient<IAnswerMultiPercentageService, AnswerMultiPercentageService>();
            return services;
        }
    }
}
