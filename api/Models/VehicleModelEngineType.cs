using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
	public class VehicleModelEngineType
	{
		public int VehicleModelId { get; set; }
		public VehicleModel VehicleModel { get; set; }

		public int EngineTypeId { get; set; }
		public EngineType EngineType { get; set; }
	}
}