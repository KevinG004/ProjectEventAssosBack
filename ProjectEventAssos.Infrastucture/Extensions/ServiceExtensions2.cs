using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ProjectEventAssos.Core.Interfaces.Repositories;
using ProjectEventAssos.Core.Interfaces.Services;
using ProjectEventAssos.Core.Interfaces.Tools;
using ProjectEventAssos.Core.Service.Auth;
using ProjectEventAssos.Core.Services;
using ProjectEventAssos.Core.Services.Auth;
using ProjectEventAssos.Domain.Models;
using ProjectEventAssos.Infrastucture.DataBase.DataContext;
using ProjectEventAssos.Infrastucture.Repositories;
using ProjectEventAssos.SecurityTools.Services;
using ProjectEventAssos.SecurityTools.Tools;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectEventAssos.Infrastucture.Extensions
{
    public static class ServiceExtensions2
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Ajouter toutes les configurations liées à l'Infrastructure (ex: DbContext, Repositories, etc.)
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<AssocEventContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IPasswordHashService, HashPassword>();
            services.AddScoped<IPasswordGenerateService, PasswordGenerateService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();
            services.AddScoped<IEventRepository, EventRepository>();
            services.AddScoped<IParticipeEventRepository, ParticipeEventRepository>();
            services.AddScoped<IWaitingListEventRepository, WaitingListRepository>();
            services.AddScoped<IEventService, EventService>();
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        }
    }
}
