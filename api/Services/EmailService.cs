using System.Net.Mail;
using api.Interfaces;

namespace api.Services
{
    public class EmailService : IEmailService
    {
        private string LoadTemplate(string templateName)
        {
            var rootPath = Directory.GetCurrentDirectory(); // Get the current working directory
            var templatePath = Path.Combine(rootPath, "EmailTemplates", $"{templateName}.html"); // Construct the full path

            if (!File.Exists(templatePath))
            {
                throw new FileNotFoundException($"Template file not found: {templatePath}");
            }

            return File.ReadAllText(templatePath);
        }

        private string PopulateTemplate(string template, (string Placeholder, string Value)[] replacements)
        {
            foreach (var (placeholder, value) in replacements)
            {
                template = template.Replace(placeholder, value);
            }
            return template;
        }

        public async Task SendEmailAsync(string email, string subject, string nameOfUser, string link, string templateName)
        {
            using (var client = new SmtpClient("localhost", 1025)) // MailHog SMTP server address and port
            {
                var template = LoadTemplate(templateName);
                var body = PopulateTemplate(template, new (string, string)[]
                {
                    ("{nameOfUser}", nameOfUser),
                    ("{link}", link)
                });

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("VehicleBooking@example.com"), // Replace with your sender email address
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true // Set to true because the message body is in HTML format
                };

                mailMessage.To.Add(email);

                await client.SendMailAsync(mailMessage);
            }
        }

        public async Task SendEmailCardAsync(string email, string subject, string nameOfUser, string maskedCardNumber, string templateName)
        {
            using (var client = new SmtpClient("localhost", 1025)) // MailHog SMTP server address and port
            {
                var template = LoadTemplate(templateName);
                var body = PopulateTemplate(template, new (string, string)[]
                {
                    ("{nameOfUser}", nameOfUser),
                    ("maskedCardNumber", maskedCardNumber)

                });

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("VehicleBooking@example.com"), // Replace with your sender email address
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true // Set to true because the message body is in HTML format
                };

                mailMessage.To.Add(email);

                await client.SendMailAsync(mailMessage);
            }
        }

        public async Task sendEmailDeleteAsync(string email, string subject, string nameOfUser, string maskedCardNumber, string templateName)
        {
            using (var client = new SmtpClient("localhost", 1025)) // MailHog SMTP server address and port
            {
                var template = LoadTemplate(templateName);
                var body = PopulateTemplate(template, new (string, string)[]
                {
                    ("{nameOfUser}", nameOfUser),
                    ("maskedCardNumber", maskedCardNumber)

                });

                var mailMessage = new MailMessage
                {
                    From = new MailAddress("VehicleBooking@example.com"), // Replace with your sender email address
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true // Set to true because the message body is in HTML format
                };

                mailMessage.To.Add(email);

                await client.SendMailAsync(mailMessage);
            }
        }
    }
}