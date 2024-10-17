using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface ITimeSlotRepository
    {
        Task<bool> IsTimeSlotAvailableAsync(int timeSlotId, DateTime desiredDateTime);
        Task AssignTimeSlotToBookingAsync(int bookingId, int timeSlotId);
        Task<TimeSlot> GetAvailableTimeSlotAsync(int serviceTypeId, DateTime desiredDateTime);
    }
}