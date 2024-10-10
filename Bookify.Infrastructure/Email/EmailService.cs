using Bookify.Application.Abstractions.Emails;

s;

namespace Bookify.Infrastructure.Email
{
    public sealed class EmailService : IEmailService
    {
        public Task SendAsync(Domain.Users.Email recepient, string Subject, string Body)
        {
            return Task.CompletedTask;
        }
    }
}
