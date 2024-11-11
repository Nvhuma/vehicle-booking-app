namespace api.Models
{

using System.Collections.Generic;



	public class Employee
	{
		public int EmployeeId { get; set; }
		public string? Name { get; set; }
		public required string ServiceSpecialty { get; set; }
		public bool IsAvailable { get; set; } = true;

		public List<string>? ServiceTypes { get; set; }

		public List<Booking>? Bookings { get; set; }
	}
}