using Domain.DomainObjects;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Infrastructure.Context;
using Infrastructure.Repositories;
using Infrastructure.Services;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Reflection;
using System.Text;

namespace CrossCuting
{
    public static class ServicesDependencyInjection
    {
        private const string applicationProjectName = "Applications";


        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration.GetSection("Secrets").Value)),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });


            var assembly = Assembly.Load(applicationProjectName);
            services.AddScoped<IAccessManagerService, AccessManagerService>();

            services.AddDbContext<PdvContext>(options =>
                 options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"),
                 o => o.UseQuerySplittingBehavior(QuerySplittingBehavior.SplitQuery)));

            services.AddMediatr();

           


            return services;

        }

        public static IServiceCollection AddRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IUserRepository, UserRepository>();

            return services;

        }

        private static void AddMediatr(this IServiceCollection services)
        {
            var assembly = Assembly.Load(applicationProjectName);

            //IDomainValidationHandlers Validators.
            services.Scan(scan => scan
                .FromAssemblies(assembly)
                .AddClasses(classes => classes.AssignableTo<IDomainValidationHandler>())
                .AsImplementedInterfaces()
                .WithTransientLifetime());

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load(applicationProjectName)));
        }
    }
}
