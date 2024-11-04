using System.Security.Claims;
using api.DTOs.BookingsDtos;
using api.Interfaces;
using api.Models;
using api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class BookingsController : ControllerBase
{
    private readonly BookingService _bookingService;
	  private readonly IEmailService _emailService;
    private readonly UserManager<AppUser> _userManager;

    public BookingsController(BookingService bookingService, UserManager<AppUser> userManager,   IEmailService emailService)
    {
        _bookingService = bookingService;
        _userManager = userManager;
				  _emailService = emailService;

    }
[HttpPost]
public async Task<IActionResult> CreateBooking([FromBody] BookingRequestModel request)
{
    if (request == null)
    {
        return BadRequest("Invalid request.");
    }

    // Retrieve the logged-in user's ID from the JWT token
    var userEmail = User.FindFirstValue(ClaimTypes.Email);
    var currentUser = await _userManager.FindByEmailAsync(userEmail);

    if (currentUser == null)
    {
        return NotFound("User not found.");
    }

    // Check service and employee availability
    var (isAvailable, message) = await _bookingService.CheckAvailability(request.ServiceType, request.DesiredDateTime, request.EmployeeId);
    if (!isAvailable)
    {
        return BadRequest(new { message });
    }

    // Retrieve the vehicle model from the database based on the request
    var vehicleModel = await _bookingService.GetVehicleModelAsync(request.VehicleModelId);
    if (vehicleModel == null)
    {
        return NotFound("Vehicle model not found.");
    }

    // Retrieve the service price for the selected vehicle model and service type
    var servicePrice = await _bookingService.GetServicePriceAsync(vehicleModel.VehicleModelId, int.Parse(request.ServiceType));
    if (servicePrice == null)
    {
        return BadRequest("No price available for the selected vehicle model and service type.");
    }

    // Create the booking object
    var booking = new Booking
    {
        UserId = currentUser.Id,
        VehicleModelId = vehicleModel.VehicleModelId,
        ServiceType = request.ServiceType,
        DesiredDateTime = request.DesiredDateTime,
        EmployeeId = request.EmployeeId,
        AdditionalNotes = request.AdditionalNotes,
        BookingStatus = "Pending",
        Price = servicePrice.Price
    };

    // Persist the booking
    var createdBooking = await _bookingService.CreateBooking(booking);

    // Send booking confirmation email
    await _emailService.SendBookingConfirmationEmailAsync(
        email: currentUser.Email,
        subject: "Booking Confirmation",
        userName: currentUser.UserName,
        templateName: "BookingConfirmation",
        vehicleMake: vehicleModel.Make,
        vehicleModel: vehicleModel.Model,
        vehicleYear: vehicleModel.Year.ToString("yyyy-MM-dd HH:mm"),
        serviceType: booking.ServiceType,
        desiredDateTime: booking.DesiredDateTime.ToString("yyyy-MM-dd HH:mm"),
        employeeId: booking.EmployeeId,
        additionalNotes: booking.AdditionalNotes
    );

    return Ok(new
    {
        BookingId = createdBooking.BookingId,
        Message = "Booking successfully created",
        createdBooking.BookingStatus,
        Price = createdBooking.Price
    });
}




[HttpPut("{bookingId}")]
	public async Task<IActionResult> UpdateBooking(int bookingId, [FromBody] BookingRequestModel request)
	{
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		// Fetch the booking to be updated
		var booking = await _bookingService.GetBookingByIdAsync(bookingId);
		if (booking == null)
		{
			return NotFound(new { message = "Booking not found." });
		}

		// Validate that the booking can be updated (e.g., within 12 hours)
		var timeUntilBooking = booking.DesiredDateTime - DateTime.UtcNow;
		if (timeUntilBooking < TimeSpan.FromHours(12))
		{
			return BadRequest(new { message = "Bookings can only be updated up to 12 hours before the scheduled time." });
		}

		// Check if the serviceType has changed
		if (booking.ServiceType != request.ServiceType)
		{
			// Fetch the price for the updated service type and vehicle model
			try
			{
				var servicePrice = await _bookingService.GetServicePriceAsync(booking.VehicleModelId, int.Parse(request.ServiceType));
				booking.Price = servicePrice.Price; // Update the booking price with the new service price
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		// Update other fields
		booking.ServiceType = request.ServiceType;
		booking.DesiredDateTime = request.DesiredDateTime;
		booking.EmployeeId = request.EmployeeId;
		booking.AdditionalNotes = request.AdditionalNotes;

		// Save changes
		var (success, message) = await _bookingService.UpdateBookingAsync(bookingId, request);

		if (!success)
		{
			return BadRequest(new { message });
		}

		return Ok(new { message = "Booking updated successfully.", booking });
	}
    
    }

