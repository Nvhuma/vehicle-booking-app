namespace api.Models
{

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


	public class DriveTrain
	{
		public int DriveTrainId { get; set; }
		public required  string DriveTrainName { get; set; }  // "FWD", "AWD", etc.
		public  ICollection<VehicleModelDriveTrain> ? VehicleModelDriveTrains { get; set; }
	}
}