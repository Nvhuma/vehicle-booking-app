namespace api.Models
{

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


	public class FuelType
	{
		public int FuelTypeId { get; set; }
		public string? FuelTypeName { get; set; }  // "Gasoline", "Hybrid", etc.
		public ICollection<VehicleModelFuelType>? VehicleModelFuelTypes { get; set; }
	}
}