namespace api.Models
{

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


	public class VehicleModelFuelType
	{
		public int VehicleModelId { get; set; }
		public VehicleModel? VehicleModel { get; set; }

		public int FuelTypeId { get; set; }
		public FuelType? FuelType { get; set; }
	}
}