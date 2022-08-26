using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Agenda.Application.Interfaces.Services;
using Agenda.Application.Services;
using Agenda.Domain.Interfaces;
using Agenda.Domain.Interfaces.Repositories;
using Agenda.Infrastructure.Data;
using Agenda.Infrastructure.Repositories;
using Agenda.Infrastructure.Unity;

namespace Agenda.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddDbContext<AgendaDbContext>();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IUnityOfWork, UnitOfWork>();

            return services;
        }
        
    }
}