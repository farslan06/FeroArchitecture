using Core.Application.Pipelines.Authorization;
using Core.Application.Pipelines.Validation;
using Core.Security.JWT;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using PL.Application.Features.Auth.Rules;
using PL.Application.Features.ProgrammingLanguages.Rules;
using PL.Application.Features.SocialLinks.Rules;
using PL.Application.Features.Technologies.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace PL.Application
{
    public static class ApplicationServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddScoped<ProgrammingLanguageBusinessRules>();
            services.AddScoped<TechnologiesBusinessRules>();
            services.AddScoped<AuthBusinessRules>();
            services.AddScoped<SocialLinkBusinessRules>();
            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(AuthorizationBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            return services;
        }       
    }
}
