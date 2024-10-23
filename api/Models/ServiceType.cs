using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class ServiceType
    {
        public int ServiceTypeId { get; set; }
		public string? Name { get; set; }
		public string? Description { get; set; }

		 public ICollection<ServicePrice> ServicePrice { get; set; }


		 public ICollection<Booking> Bookings { get; set; }

		 public ICollection<Employee> Employees { get; set; } // via EmployeeService

	
    }
}