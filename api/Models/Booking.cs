using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Booking
    {
    public int BookingId { get; set; }
    public string UserId { get; set; }
		public decimal Price { get; set; }
    public int VehicleModelId { get; set; }
    public VehicleModel Vehicle { get; set; }
    public string ServiceType { get; set; }
    public DateTime DesiredDateTime { get; set; }
    public string ? EmployeeId { get; set; } // Nullable
   
    public string ? AdditionalNotes { get; set; }
    public string BookingStatus { get; set; } // Pending, Confirmed, Cancelled

		public AppUser AppUser { get; set;}
    }
}