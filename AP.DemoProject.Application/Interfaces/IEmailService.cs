namespace AP.DemoProject.Application.Interfaces;

public interface IEmailService
{
    public Task SendEmail(string to, string subject, string message);
}