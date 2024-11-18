

namespace api.DTOs.AdminDtos
{
	
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

	public class ServicePriceDto
	{
		public int Id { get; set; }
		public int VehicleModelId { get; set; }
		public required string Make { get; set; }
		public required string Model { get; set; }
		// Add more fields as needed
		public required string HorsepowerRange { get; set; }
		public required string TorqueRange { get; set; }
		public required int MaxTowingCapacity { get; set; }
		public required string EmissionStandard { get; set; }
		public int Year { get; set; }
		public int ServiceTypeId { get; set; }
		public decimal Price { get; set; }
	}

}