namespace api.DTOs.VehicleModelDtos
{

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


	public class EngineTypeDto
	{
		public int EngineTypeId { get; set; }
		public string EngineTypeName { get; set; }
	}

	public class TransmissionTypeDto
	{
		public int TransmissionTypeId { get; set; }
		public string TransmissionTypeName { get; set; }
	}

	public class DriveTrainDto
	{
		public int DriveTrainId { get; set; }
		public string DriveTrainName { get; set; }
	}

	public class FuelTypeDto
	{
		public int FuelTypeId { get; set; }
		public string FuelTypeName { get; set; }
	}

	public class TrimLevelDto
	{
		public int TrimLevelId { get; set; }
		public string TrimLevelName { get; set; }
	}
}