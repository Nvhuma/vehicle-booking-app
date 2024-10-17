using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class EmployeeService
    {  [Key]
		     public int EmployeeServiceId { get; set; }
        public int EmployeeId { get; set; }
				public Employee Employee { get; set; }

				public int ServiceTypeId  { get; set; }

				public ServiceType ServiceType {get; set;}
    }
}