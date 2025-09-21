using AP.DemoProject.Application.Interfaces;

namespace AP.DemoProject.Infrastructure.Services;

public class EmailService : IEmailService
{
    public Task SendEmail(string to, string subject, string message)
    {
        Console.WriteLine($"Sending email to {to}\n subject: {subject}\n Message: {message}");
        return Task.CompletedTask;
    }
}