using System;
using System.ComponentModel.DataAnnotations;

namespace api.Models
{
    public class Bookings
    {
			[Key]
        public int BookingId { get; set; }

				 public DateTime DesiredDateTime { get; set; }

        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; }

        public int EmployeeId { get; set; } // Assigned employee
        public Employee Employee { get; set; }

        public int TimeSlotID { get; set; } // Foreign key for TimeSlot
        public TimeSlot TimeSlot { get; set; } // Navigation property for TimeSlot
    }
}
