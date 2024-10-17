namespace api.Models
{
	using System;

	public class ServiceType
	{
		public int ServiceTypeId { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }

		 public ICollection<ServicePrice> ServicePrice { get; set; }


		 public ICollection<Bookings> Bookings { get; set; }

		 public ICollection<Employee> Employees { get; set; } // via EmployeeService

		 public ICollection<EmployeeService> EmployeeServices { get; set; }
		  public ICollection<TimeSlot> TimeSlots { get; set; }
	}
}
