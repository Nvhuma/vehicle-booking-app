using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
	public class TrimLevel
	{
		public int TrimLevelId { get; set; }
		public string TrimLevelName { get; set; }  // "SE", "XLE", etc.
		public ICollection<VehicleModelTrimLevel> VehicleModelTrimLevels { get; set; }
	}
}