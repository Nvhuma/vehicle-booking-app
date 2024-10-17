using api.Interfaces;
using api.Models;
using api.Repositories;
using System;
using System.Threading.Tasks;

namespace api.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
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
            // TO DO: Implement business logic for creating a booking
            return await _bookingRepository.CreateBookingAsync(booking);
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