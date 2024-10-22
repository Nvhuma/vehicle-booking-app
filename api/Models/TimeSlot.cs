using System;

namespace api.Models
{
    public class TimeSlot
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public bool IsAvailable { get; set; }
        public int ? BookingId { get; set; } // Foreign key for Booking (if occupied)
        public Bookings Booking { get; set; } // Navigation property for Booking

        public int ServiceTypeId { get; set; }
        public ServiceType ServiceType { get; set; } // Service this time slot is for

        public int EmployeeId { get; set; } // Employee assigned (if any)
        public Employee Employee { get; set; }
    }
}
