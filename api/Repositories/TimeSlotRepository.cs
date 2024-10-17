using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Repositories
{
    public class TimeSlotRepository : ITimeSlotRepository
    {
        private readonly ApplicationDBContext _context;

        public TimeSlotRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<bool> IsTimeSlotAvailableAsync(int timeSlotId, DateTime desiredDateTime)
        {
            var timeSlot = await _context.TimeSlots.FindAsync(timeSlotId);
            if (timeSlot!= null)
            {
                return (desiredDateTime >= timeSlot.StartTime && desiredDateTime <= timeSlot.EndTime) && timeSlot.IsAvailable;
            }
            return false;
        }

        public async Task AssignTimeSlotToBookingAsync(int bookingId, int timeSlotId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            var timeSlot = await _context.TimeSlots.FindAsync(timeSlotId);
            if (booking!= null && timeSlot!= null)
            {
                booking.TimeSlotID = timeSlotId;
                timeSlot.BookingId = bookingId;
                timeSlot.IsAvailable = false;
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TimeSlot> GetAvailableTimeSlotAsync(int serviceTypeId, DateTime desiredDateTime)
        {
            return await _context.TimeSlots
              .Where(ts => ts.ServiceTypeId == serviceTypeId 
                             && ts.StartTime <= desiredDateTime 
                             && ts.EndTime >= desiredDateTime 
                             && ts.IsAvailable)
              .FirstOrDefaultAsync();
        }
    }
}