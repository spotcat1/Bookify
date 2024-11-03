using Bookify.Application.Abstractions.Clocks;
using Bookify.Application.Abstractions.Data;
using Bookify.Application.Abstractions.Emails;
using Bookify.Application.Data;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Bookings;
using Bookify.Domain.Users;
using Bookify.Infrastructure.Clock;
using Bookify.Infrastructure.Email;
using Bookify.Infrastructure.Repositories;
using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection.Emit;

namespace Bookify.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {



            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IDateTimeProvider, DateTimeProvider>();

            var connectionString = configuration["ConnectionStrings:DataBase"] ??
                                   throw new NotImplementedException("Connection string not found.");


            services.AddDbContext<ApplicationDbContext>(options =>
                 options.UseSqlServer(connectionString, sqlOptions =>
                 {
                     sqlOptions.EnableRetryOnFailure(
                         maxRetryCount: 5,
                         maxRetryDelay: TimeSpan.FromSeconds(10),
                         errorNumbersToAdd: null);
                 })
                 .UseSnakeCaseNamingConvention() // Apply snake_case naming convention
             );

            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IApartmentRepository, ApartmentRepository>();

            services.AddScoped<IBookingRepository, BookingRepository>();

            services.AddScoped<IUnitOfWork>(_ => _.GetRequiredService<ApplicationDbContext>());

            services.AddSingleton<ISqlConnectionFactory>(x=>new SqlConnectionFactory(connectionString));

            SqlMapper.AddTypeHandler(new DateOnlyTypeHandler());

            return services;
        }
    }
}
