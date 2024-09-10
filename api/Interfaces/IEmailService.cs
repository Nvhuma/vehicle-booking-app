namespace api.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string nameOfUser, string link, string templateName);
    }
}