using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
	public class DriveTrain
	{
		public int DriveTrainId { get; set; }
		public string DriveTrainName { get; set; }  // "FWD", "AWD", etc.
		public ICollection<VehicleModelDriveTrain> VehicleModelDriveTrains { get; set; }
	}
}