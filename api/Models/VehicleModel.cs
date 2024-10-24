using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
	public class VehicleModel
	{
		public int VehicleModelId { get; set; }
		public string Make { get; set; }
		public string Model { get; set; }
		public int Year { get; set; }
		public string HorsepowerRange { get; set; }
		public string TorqueRange { get; set; }
		public int MaxTowingCapacity { get; set; }
		public string EmissionStandard { get; set; }

		public ICollection<ServicePrice> ServicePrice { get; set; }
		// Navigation properties for many-to-many relationships
    public ICollection<VehicleModelEngineType> VehicleModelEngineTypes { get; set; }
    public ICollection<VehicleModelTransmissionType> VehicleModelTransmissionTypes { get; set; }
    public ICollection<VehicleModelDriveTrain> VehicleModelDriveTrains { get; set; }
    public ICollection<VehicleModelFuelType> VehicleModelFuelTypes { get; set; }
    public ICollection<VehicleModelTrimLevel> VehicleModelTrimLevels { get; set; }

	}
}
