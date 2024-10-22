using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.DTOs.BookingsDtos
{
    public class BookingsDTO
    {
        public int ServiceTypeId { get; set; }
        public DateTime DesiredDateTime { get; set; }

				public AppUser AppUser  { get; set; }

				public int EmployeeId { get; set; }

				public int TimeSlotID { get; set; }
				
    }
}