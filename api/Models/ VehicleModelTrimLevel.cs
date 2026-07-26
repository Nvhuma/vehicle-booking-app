using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
	public class VehicleModelTrimLevel
	{
		public int VehicleModelId { get; set; }
		public VehicleModel VehicleModel { get; set; }
		
		public int TrimLevelId { get; set; }
		public TrimLevel TrimLevel { get; set; }
	}
}