using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
	public class VehicleModelDriveTrain
	{
		public int VehicleModelId { get; set; }
		public VehicleModel VehicleModel { get; set; }

		public int DriveTrainId { get; set; }
		public DriveTrain DriveTrain { get; set; }
	}
}