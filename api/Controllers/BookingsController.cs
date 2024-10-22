using api.DTOs.BookingsDtos;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;


namespace api.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class BookingsController : ControllerBase
	{
		private readonly IBookingService _bookingService;

		public BookingsController(IBookingService bookingService)
		{
			_bookingService = bookingService;
		}


		[HttpPost]
		public async Task<ActionResult<Bookings>> CreateBooking(BookingsDTO bookingDTO)
		{
			var booking = new Bookings
			{
				ServiceTypeId = bookingDTO.ServiceTypeId,
				DesiredDateTime = bookingDTO.DesiredDateTime,
				// **Other properties...**
			};

			var createdBooking = await _bookingService.CreateBookingAsync(booking);
			return CreatedAtAction(nameof(CreateBooking), new { id = createdBooking.BookingId }, createdBooking);
		}


		// **GET: Get All Bookings**
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Bookings>>> GetAllBookings()
		{
			var bookings = await _bookingService.GetAllBookingsAsync();
			return Ok(bookings); // Wrap in OkActionResult
		}

		// **GET: Get Booking by ID**
		[HttpGet("{id}")]
		public async Task<ActionResult<Bookings>> GetBookingById(int id)
		{
			var booking = await _bookingService.GetBookingByIdAsync(id);
			if (booking == null)
			{
				return NotFound();
			}
			return booking;
		}

		// **PUT: Update Existing Booking**
		[HttpPut("{id}")]
		public async Task<ActionResult> UpdateBooking(int id, BookingsDTO bookingDTO)
		{
			var booking = await _bookingService.GetBookingByIdAsync(id);
			if (booking == null)
			{
				return NotFound();
			}

			booking.ServiceTypeId = bookingDTO.ServiceTypeId;
			booking.DesiredDateTime = bookingDTO.DesiredDateTime;
			// **Update other properties...**

			await _bookingService.UpdateBookingAsync(booking);
			return NoContent();
		}

		// **DELETE: Delete Booking by ID**
		[HttpDelete("{id}")]
		public async Task<ActionResult> DeleteBooking(int id)
		{
			var booking = await _bookingService.GetBookingByIdAsync(id);
			if (booking == null)
			{
				return NotFound();
			}

			await _bookingService.DeleteBookingAsync(id);
			return NoContent();
		}
	}
}