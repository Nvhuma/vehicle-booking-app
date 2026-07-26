using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
	public class TransmissionType
	{
		public int TransmissionTypeId { get; set; }
		public string TransmissionTypeName { get; set; }  // "Automatic", "Manual", etc.
		public ICollection<VehicleModelTransmissionType> VehicleModelTransmissionTypes { get; set; }
	}
}