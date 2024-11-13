namespace api.Controllers

{

	using api.DTOs.CardDtos;
	using api.Interfaces;
	using api.Services;
	using Microsoft.AspNetCore.Mvc;
	using api.Models;
	using api.DTOs.BookingsDtos;

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
    // Validate the payment request
    if (paymentRequest == null || string.IsNullOrWhiteSpace(paymentRequest.CardNumber) ||
        string.IsNullOrWhiteSpace(paymentRequest.CardExpiry) || string.IsNullOrWhiteSpace(paymentRequest.CardCvc))
    {
        return BadRequest("Invalid payment request. Card details are required.");
    }

    try
    {
        // Process the payment
        var paymentResult = await _paymentProcessor.ProcessPaymentAsync(paymentRequest);

        if (paymentResult.IsSuccess)
        {
            // Retrieve the booking
            var booking = await _bookingService.GetBookingByIdAsync(paymentRequest.BookingId);

            if (booking == null)
            {
                return NotFound($"Booking with ID {paymentRequest.BookingId} not found.");
            }

            // Update the booking status
            booking.BookingStatus = Booking.StatusConfirmed;

            // Create a BookingRequestModel instance and map the necessary properties
            var bookingRequestModel = new BookingRequestModel
            {
              
                ServiceType = booking.ServiceType,
                DesiredDateTime = booking.DesiredDateTime,
                EmployeeId = booking.EmployeeId,
                AdditionalNotes = booking.AdditionalNotes,
                VehicleModelId = booking.VehicleModelId
            };

            // Update the booking in the database
            await _bookingService.UpdateBookingAsync(paymentRequest.BookingId, bookingRequestModel);

            // Return the successful payment result
            return Ok(paymentResult);
        }
        else
        {
            // Return the payment failure result with a more detailed error message
            return BadRequest($"Payment failed. Reason: {paymentResult.Message}");
        }
    }
    catch (Exception ex)
    {
        // Log the exception and return a generic error message
        // _logger.LogError(ex, "An error occurred while processing payment.");
        return StatusCode(500, "An error occurred while processing the payment. Please try again later.");
    }
}
	}
}