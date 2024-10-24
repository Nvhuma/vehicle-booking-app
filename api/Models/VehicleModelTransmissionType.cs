using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
  public class VehicleModelTransmissionType
  {
    public int VehicleModelId { get; set; }
    public VehicleModel VehicleModel { get; set; }

    public int TransmissionTypeId { get; set; }
    public TransmissionType TransmissionType { get; set; }
  }
}