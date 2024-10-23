using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.BookingsDtos
{
    public class BookingRequestModel
    {
    public VehicleRequestModel Vehicle { get; set; }
    public string ServiceType { get; set; }
    public DateTime DesiredDateTime { get; set; }
    public string EmployeeId { get; set; }
    public string AdditionalNotes { get; set; }
    }
}