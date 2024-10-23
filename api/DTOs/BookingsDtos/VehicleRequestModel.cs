using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.BookingsDtos
{
	public class VehicleRequestModel
	{
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
	}
}