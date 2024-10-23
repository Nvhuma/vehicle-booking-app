using api.Data;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
    public class BookingService
    {
        private readonly ApplicationDBContext _context;

        public BookingService(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<(bool IsAvailable, string Message)> CheckAvailability(string serviceType, DateTime desiredDateTime, string employeeId = null)
        {
            // Check for conflicts for the selected service type
            var conflictingServiceBooking = await _context.Bookings
                .AnyAsync(b => b.ServiceType == serviceType && b.DesiredDateTime == desiredDateTime);

            if (conflictingServiceBooking)
            {
                return (false, "Time slot is unavailable for the selected service.");
            }

            // If an employee ID is provided, check for conflicts with that specific employee
            if (!string.IsNullOrEmpty(employeeId))
            {
                var employeeConflict = await _context.Bookings
                    .AnyAsync(b => b.EmployeeId == employeeId && b.DesiredDateTime == desiredDateTime && b.ServiceType == serviceType);

                if (employeeConflict)
                {
                    return (false, "The selected employee is not available at the requested time for this service.");
                }

                // Optional: Check if the employee is available for any other service at that time
                var employeeAvailableForOtherServices = await _context.Bookings
                    .AnyAsync(b => b.EmployeeId == employeeId && b.DesiredDateTime == desiredDateTime);

                if (employeeAvailableForOtherServices)
                {
                    // You could return a message stating that the employee is booked for another service

										 return (false, "Selected employee is not available at the requested time.");
                }
            }

            return (true, "Time slot is available.");
        }

        public async Task<Booking> CreateBooking(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }
    }
}
