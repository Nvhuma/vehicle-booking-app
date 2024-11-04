
using api.DTOs.CardDtos;
using api.Interfaces;
using api.Services;
using Microsoft.AspNetCore.Mvc;
using api.Models;

namespace api.Controllers
{
	[ApiController]
	[Route("api/v1/payments")]
	public class PaymentController : ControllerBase
	{
		private readonly IPaymentProcessor _paymentProcessor;
		private readonly BookingService _bookingService;


		public PaymentController(IPaymentProcessor paymentProcessor, BookingService bookingService)
		{
			_paymentProcessor = paymentProcessor;
			_bookingService = bookingService;

		}

		[HttpPost]
public async Task<IActionResult> ProcessPayment([FromBody] PaymentRequest paymentRequest)
{
    // Check if the paymentRequest is null
    if (paymentRequest == null)
    {
        return BadRequest("Payment request cannot be null.");
    }

    // Validate card details (you can add more thorough checks as needed)
    if (string.IsNullOrWhiteSpace(paymentRequest.CardNumber) ||
        string.IsNullOrWhiteSpace(paymentRequest.CardExpiry) ||
        string.IsNullOrWhiteSpace(paymentRequest.CardCvc))
    {
        return BadRequest("Card details are required.");
    }

    try
    {
        // Process payment
        var paymentResult = await _paymentProcessor.ProcessPaymentAsync(paymentRequest);

        if (paymentResult.IsSuccess)
        {
            // Retrieve the booking
            var booking = await _bookingService.GetBookingByIdAsync(paymentRequest.BookingId);

            // Check if booking exists
            if (booking == null)
            {
                return NotFound($"Booking with ID {paymentRequest.BookingId} not found.");
            }

            // Set the BookingStatus to Confirmed
            booking.BookingStatus = Booking.StatusConfirmed;

            // Update the booking status in the database
            await _bookingService.UpdateBookingAsync(booking);

            return Ok(paymentResult);
        }
        else
        {
            return BadRequest(paymentResult);
        }
    }
    catch (Exception ex)
    {
        // Log the exception (consider using a logging framework)
        // _logger.LogError(ex, "An error occurred while processing payment.");
        
        return StatusCode(500, "An error occurred while processing the payment.");
    }
}

	}
}