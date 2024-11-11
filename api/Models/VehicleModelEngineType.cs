namespace api.Models
{

using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;


	public class VehicleModelEngineType
	{
		public int VehicleModelId { get; set; }
		
		[Required]
		public VehicleModel? VehicleModel { get; set; }

		public int EngineTypeId { get; set; }
		
		[Required]
		public EngineType ?EngineType { get; set; }
	}
}