using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Employee
    {
    public int EmployeeId { get; set; }
    public string Name { get; set; }
    public string ServiceSpecialty { get; set; } // E.g., oil change, tire rotation
		public bool IsAvailable { get; set; } = true;
		
    }
}