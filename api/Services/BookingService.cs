using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Services
{
    public class BookingService : IBookingService
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<AppUser> _userManager;
        private readonly IBookingRepository _bookingRepository;

        // Combined constructor that accepts all dependencies
        public BookingService(ApplicationDBContext context, UserManager<AppUser> userManager, IBookingRepository bookingRepository)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
        }

        public async Task<IEnumerable<Bookings>> GetAllBookingsAsync()
        {
            return await _bookingRepository.GetAllBookingsAsync();
        }

        public async Task<Bookings> GetBookingByIdAsync(int id)
        {
            return await _bookingRepository.GetBookingByIdAsync(id);
        }

        public async Task<Bookings> CreateBookingAsync(Bookings booking)
        {
            // Check if the employee is available for the selected service type
            var employee = await _context.Employees.FindAsync(booking.EmployeeId);
            if (employee == null)
            {
                throw new InvalidOperationException($"Employee with Id {booking.EmployeeId} does not exist.");
            }

            // Check if the employee has available time slots for the selected service type
            var availableTimeSlots = await _context.TimeSlots
                 .Where(ts => ts.EmployeeId == booking.EmployeeId && ts.ServiceTypeId == booking.ServiceTypeId && ts.IsAvailable)
                 .ToListAsync();

            if (!availableTimeSlots.Any())
            {
                throw new InvalidOperationException($"No available time slots found for Employee {booking.EmployeeId} and Service Type {booking.ServiceTypeId}.");
            }

            // Check if the selected time slot is available
            var selectedTimeSlot = availableTimeSlots.FirstOrDefault(ts => ts.Id == booking.TimeSlotID);
            if (selectedTimeSlot == null || !selectedTimeSlot.IsAvailable)
            {
                throw new InvalidOperationException($"Time Slot {booking.TimeSlotID} is not available for Employee {booking.EmployeeId} and Service Type {booking.ServiceTypeId}.");
            }

            // If all checks pass, create the booking
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task UpdateBookingAsync(Bookings booking)
        {
            await _bookingRepository.UpdateBookingAsync(booking);
        }

        public async Task DeleteBookingAsync(int id)
        {
            await _bookingRepository.DeleteBookingAsync(id);
        }
    }
}
