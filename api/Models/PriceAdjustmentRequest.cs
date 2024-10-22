using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

//acting as a DTO for priceadjustmentRequest

namespace api.Models
{
    public class PriceAdjustmentRequest
    {
         public double Percentage { get; set; }
         
    }
}
