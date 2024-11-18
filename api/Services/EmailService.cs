

namespace api.Services
{
	using System.Net.Mail;
	using api.Data;
	using api.Interfaces;

	public class EmailService : IEmailService
	{
		private readonly ApplicationDBContext _context;

		public EmailService(ApplicationDBContext context)
		{
			_context = context;


		}


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
			using (var client = new SmtpClient("localhost", 1025))
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

		public async Task SendBookingConfirmationEmailAsync(string email, string subject, string userName, string templateName, int VehicleModelId, string serviceType, string desiredDateTime, int employeeId, string additionalNotes)
		{
			// Retrieve vehicle details based on modelId
			var vehicle = await _context.VehicleModels.FindAsync(VehicleModelId);
			if (vehicle == null)
			{
				throw new Exception("Vehicle not found.");
			}

			// Retrieve employee details based on employeeId
			var employee = await _context.Employee.FindAsync(employeeId);
			if (employee == null)
			{
				throw new Exception("Employee not found.");
			}

			using (var client = new SmtpClient("localhost", 1025)) // MailHog SMTP server
			{
				// Load the email template
				var template = LoadTemplate(templateName);

				// Populate the template with booking details, vehicle info, and employee name
				var body = PopulateTemplate(template, new (string, string)[]
				{
						("{userName}", userName),
						("{vehicleMake}", vehicle.Make),
						("{vehicleModel}", vehicle.Model),
						("{vehicleYear}", vehicle.Year.ToString()),
						("{serviceType}", serviceType),
						("{desiredDateTime}", desiredDateTime),
						("{employeeName}", employee.Name),
						("{additionalNotes}", additionalNotes)
				});

				// Configure the email message
				var mailMessage = new MailMessage
				{
					From = new MailAddress("VehicleBooking@example.com"),
					Subject = subject,
					Body = body,
					IsBodyHtml = true
				};

				// Add recipient email
				mailMessage.To.Add(email);

				// Send the email
				await client.SendMailAsync(mailMessage);
			}
		}
	}
}

