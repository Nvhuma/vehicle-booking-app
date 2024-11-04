using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class PaymentResult
    {
        public bool IsSuccess { get; set; }
        public string? Message { get; set; }
        public string ? PaymentId { get; set; }

    }
}