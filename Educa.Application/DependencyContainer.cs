using AutoMapper;
using Educa.Application.Common.Interfaces;
using Educa.Application.Common.Models.BaseModels;
using Educa.Application.Interfaces;
using Educa.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Educa.Application
{
    public static class DependencyContainer
    {
        public static void AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettings = configuration.GetSection("AppSettings").Get<AppSettings>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<IIdentityService, IdentityService>();
            services.AddScoped<IPersonService, PersonService>();
        }
    }
}
