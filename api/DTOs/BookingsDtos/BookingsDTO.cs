using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.BookingsDtos
{
    public class BookingsDTO
    {
        public int ServiceTypeId { get; set; }
        public DateTime DesiredDateTime { get; set; }
    }
}