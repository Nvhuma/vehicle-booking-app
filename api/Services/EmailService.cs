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

        public async Task SendEmailBookingAsync(string email, string subject, string nameOfUser, string serviceType, DateTime desiredDateTime, string templateName)
        {
            using (var client = new SmtpClient("localhost", 1025)) // MailHog SMTP server address and port
            {
                var template = LoadTemplate(templateName);
                var body = PopulateTemplate(template, new (string, string)[]
                {
                    ("{nameOfUser}", nameOfUser),
                    ("{serviceType}", serviceType),
                    ("{desiredDateTime}", desiredDateTime.ToString("yyyy-MM-dd HH:mm"))
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

        public addition (int a, int b)
        {
            return a + b;

            // 5 + 3 = 8
            // 10 + 2 = 12
            // 7 + 4 = 11
        }

        public subtraction (int a, int b)
        {
            return a - b;

            // 5 - 3 = 2
            // 10 - 2 = 8
            // 7 - 4 = 3
        }

        public multiplication (int a, int b)
        {
            return a * b;

            // 5 * 3 = 15
            // 10 * 2 = 20
            // 7 * 4 = 28
            
        }


    }
}