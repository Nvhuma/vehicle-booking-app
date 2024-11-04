namespace api.Interfaces
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string nameOfUser, string link,  string templateName);

        Task SendEmailCardAsync(string email, string subject, string nameOfUser, string maskedCardNumber, string templateName);

        Task sendEmailDeleteAsync(string email, string subject, string nameOfUser, string maskedCardNumber, string templateName);

        Task SendBookingConfirmationEmailAsync(
        string email,
        string subject,
        string userName,
        string templateName,
        string vehicleMake,
        string vehicleModel,
        string vehicleYear,
        string serviceType,
        string desiredDateTime,
        string employeeId,
        string additionalNotes);
        
    }
}