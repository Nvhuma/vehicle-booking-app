namespace api.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string nameOfUser, string link,  string templateName);

        Task SendEmailCardAsync(string email, string subject, string nameOfUser, string maskedCardNumber, string templateName);

        Task sendEmailDeleteAsync(string email, string subject, string nameOfUser, string maskedCardNumber, string templateName);


        
    }
}