namespace Bookify.Application.Abstractions.Emails
{
    public interface IEmailService
    {
        Task SendAsync(Domain.Users.Email recepient, string Subject, String Body);
    }
}
