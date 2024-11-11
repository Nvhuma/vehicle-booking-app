namespace api.Models
{

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


	public class EngineType
	{
		public int EngineTypeId { get; set; }
		public string ? EngineTypeName { get; set; }  // "I4", "V6", etc.
		public ICollection<VehicleModelEngineType> ?VehicleModelEngineTypes { get; set; }
	}
}