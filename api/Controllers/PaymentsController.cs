using Microsoft.AspNetCore.Mvc;
using api.Models;
using api.Interfaces;
using api.DTOs.CardDtos;
using api.Data;

namespace TestPaymentGateway.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly ICardDetailsService _cardDetailsService;
				  private readonly ApplicationDBContext _context;

        public PaymentsController(ICardDetailsService cardDetailsService,  ApplicationDBContext context)
        {
            _cardDetailsService = cardDetailsService;
						 _context = context;
        }

				[HttpPost]
        public IActionResult ProcessPayment([FromBody] PaymentRequest request)
        {
            // Retrieve the booking associated with the provided BookingId
            var booking = _context.Bookings.FirstOrDefault(b => b.BookingId == request.BookingId);

            if (booking == null)
            {
                return BadRequest(new { success = false, message = "Booking not found" });
            }

            // Check if the payment amount matches the booking price
            if (request.Amount != booking.Price)
            {
                return BadRequest(new { success = false, message = "Payment amount does not match booking cost" });
            }

            // Validate card information and balance
            bool isValidCard = ValidateCard(request.CardNumber, request.CardExpiry, request.CardCvc);
            var card = _context.CardDetails.FirstOrDefault(c => c.CardNumber == request.CardNumber);

            if (!isValidCard || card == null || card.Balance < request.Amount)
            {
                return BadRequest(new { success = false, message = "Payment failed: Insufficient balance or invalid card details" });
            }

            // Deduct the amount from the card's balance
            card.Balance -= request.Amount;
            _context.SaveChanges();

            // Create and save the payment record
            var payment = new PaymentRequest
            {
                Amount = request.Amount,
                CardNumber = request.CardNumber,
                PaymentDate = DateTime.UtcNow,
                BookingId = booking.BookingId // Link to the booking
            };
            _context.PaymentRequests.Add(payment);

            // Update booking status to Confirmed
            booking.BookingStatus = Booking.StatusConfirmed;
            _context.SaveChanges();

            return Ok(new { success = true, message = "Payment successful, booking confirmed" });
        }

        private bool ValidateCard(string cardNumber, string expiry, string cvc)
        {
            // Simulate card validation logic
            return !string.IsNullOrWhiteSpace(cardNumber) && !string.IsNullOrWhiteSpace(expiry) && !string.IsNullOrWhiteSpace(cvc) && cardNumber == "4242424242424242";
        }
		}

       
}
