using Bookify.Application.Abstractions.Clocks;
using Bookify.Application.Abstractions.Emails;
using Bookify.Infrastructure.Clock;
using Bookify.Infrastructure.Email;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Bookify.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            var ConnectionString = configuration.GetConnectionString("DB") ??
            throw new NotImplementedException();

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(ConnectionString).UseSnakeCaseNamingConvention();
            });

            return services;
        }
    }
}
