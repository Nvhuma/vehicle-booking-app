using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IBookingService
    {
        Task<IEnumerable<Bookings>> GetAllBookingsAsync();
        Task<Bookings> GetBookingByIdAsync(int id);
        Task<Bookings> CreateBookingAsync(Bookings booking);
        Task UpdateBookingAsync(Bookings booking);
        Task DeleteBookingAsync(int id);
    }
}
