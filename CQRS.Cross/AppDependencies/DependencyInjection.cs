using CQRS.Application.Members.Commands.Validations;
using CQRS.Domain.Interfaces;
using CQRS.Domain.Interfaces.Members;
using CQRS.Infra.Context;
using CQRS.Infra.Repositories;
using CQRS.Infra.Repositories.Members;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;
using System.Data;
using System.Reflection;

namespace CQRS.Cross.AppDependencies
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration) 
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            services.AddScoped<IMemberRepository, MemberRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            var assemblyApplication = "CQRS.Application";

            var handlers = AppDomain.CurrentDomain.Load(assemblyApplication);
            services.AddMediatR(cfg => 
            {
                cfg.RegisterServicesFromAssemblies(handlers);
                cfg.AddOpenBehavior(typeof(ValidationBehaviour<,>));
            });

            services.AddSingleton<IDbConnection>(provider => {
                var connection = new MySqlConnection(connectionString);
                connection.Open();
                return connection;
            });

            services.AddScoped<IMemberDapperRepository, MemberDapperRepository>();

            services.AddValidatorsFromAssembly(Assembly.Load(assemblyApplication));

            return services;
        }
    }
}