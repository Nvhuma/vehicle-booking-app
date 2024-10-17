using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Employee
    {
        public int EmployeeId { get ; set; }

				public string Name { get; set;}

				public ICollection<Bookings> Bookings { get; set;}
				public ICollection<ServiceType> ServiceTypes { get; set; } //via EmployeeService

				public ICollection<EmployeeService> EmployeeServices { get; set; }

				public ICollection<TimeSlot> TimeSlots { get; set; }


    }
}