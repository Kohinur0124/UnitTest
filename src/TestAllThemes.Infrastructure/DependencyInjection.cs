using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestAllThemes.Application.Abstractions;
using TestAllThemes.Application.UseCases.Users.Repos;
using TestAllThemes.Infrastructure.Persistance;

namespace TestAllThemes.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IApplicationDbContext, ApplicationDbContext>(options =>
            {
                var con = $"Data source={Environment.GetEnvironmentVariable("DB_HOST")};" +
                            $"Initial Catalog={Environment.GetEnvironmentVariable("DB_NAME")};" +
                            $"User ID=SA;Password={Environment.GetEnvironmentVariable("SA_PASSWORD")};" +
                            $"TrustServerCertificate=True;";
                options.UseSqlServer(con);
            });

            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
