using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.DTOs.CardDtos
{
    public class UpdateBookingsRequestDto
    {
         [Required]
    public int ServiceTypeId { get; set; } // The new service type for the booking
    
    [Required]
    public DateTime DesiredDateTime { get; set; } // The new date and time for the booking

    public int? EmployeeId { get; set; } // Optional employee assignment

    [StringLength(500)]
    public string? AdditionalNotes { get; set; } // Any additional notes from the user
    }
}