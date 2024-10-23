using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class VehicleModel
    {
        public int Id { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
   

			 public ICollection<ServicePrice> ServicePrice { get; set; }

    }
}
