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
    int  VehicleModelId,           // modelId to fetch vehicle details
    string serviceType,
    string desiredDateTime,
    int employeeId,         // employeeId to fetch employee name
    string additionalNotes
);

    }
}