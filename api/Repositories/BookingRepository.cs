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
    public class BookingRepository : IBookingRepository
    {
        private readonly ApplicationDBContext _context;

        public BookingRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bookings>> GetAllBookingsAsync()
        {
            return await _context.Bookings
              .Include(b => b.ServiceType)
              .Include(b => b.Employee)
              .Include(b => b.TimeSlot)
              .ToListAsync();
        }

        public async Task<Bookings> GetBookingByIdAsync(int id)
        {
            return await _context.Bookings
              .Include(b => b.ServiceType)
              .Include(b => b.Employee)
              .Include(b => b.TimeSlot)
              .FirstOrDefaultAsync(b => b.BookingId == id);
        }

        public async Task<Bookings> CreateBookingAsync(Bookings booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task<Bookings> UpdateBookingAsync(Bookings booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task DeleteBookingAsync(int id)
        {
            var booking = await GetBookingByIdAsync(id);
            if (booking!= null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }
    }
}