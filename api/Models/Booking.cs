namespace api.Models
{

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


	public class Booking
	{
		public int BookingId { get; set; }
		public required string  UserId { get; set; }
		public decimal Price { get; set; }
		public int VehicleModelId { get; set; }
		public VehicleModel ? Vehicle { get; set; }
		public required string  ServiceType { get; set; }
		public DateTime DesiredDateTime { get; set; }
		public int EmployeeId { get; set; }            
		public required string AdditionalNotes { get; set; }

		public string BookingStatus { get; set; } = StatusPending;

		// Define status values as constants
		public const string StatusPending = "Pending";
		public const string StatusConfirmed = "Confirmed";
		public const string StatusCanceled = "Canceled";

		public AppUser ? AppUser { get; set; }

	}
}
