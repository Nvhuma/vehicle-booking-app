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

	public BookingsController(BookingService bookingService, UserManager<AppUser> userManager, IEmailService emailService)
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
		if (!int.TryParse(request.ServiceType, out int parsedServiceType))
		{
			return BadRequest("Invalid service type format.");
		}

		var servicePrice = await _bookingService.GetServicePriceAsync(vehicleModel.VehicleModelId, parsedServiceType);
		if (servicePrice == null)
		{
			return BadRequest("No price available for the selected vehicle model and service type.");
		}

		// Fetch the employee details based on the provided EmployeeId
		var employee = await _bookingService.GetEmployeeByIdAsync(request.EmployeeId);
		if (employee == null)
		{
			return NotFound("Employee not found.");
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

		// Send booking confirmation email with modelId and employeeId for database lookup
		await _emailService.SendBookingConfirmationEmailAsync(
				email: currentUser.Email,
				subject: "Booking Confirmation",
				userName: currentUser.UserName,
				templateName: "BookingConfirmation",
				VehicleModelId: vehicleModel.VehicleModelId,       // Pass modelId for vehicle details
				serviceType: booking.ServiceType,
				desiredDateTime: booking.DesiredDateTime.ToString("yyyy-MM-dd HH:mm"),
				employeeId: employee.EmployeeId,                    // Pass employeeId for employee details
				additionalNotes: request.AdditionalNotes
		);

		return Ok(new { Message = "Booking created successfully.", BookingId = createdBooking.BookingId });
	}

	[HttpGet]
	public async Task<IActionResult> GetBookingsForCurrentUser()
	{
		// Retrieve the logged-in user's ID from the JWT token
		var userEmail = User.FindFirstValue(ClaimTypes.Email);
		var currentUser = await _userManager.FindByEmailAsync(userEmail);

		if (currentUser == null)
		{
			return NotFound("User not found.");
		}

		// Fetch the bookings for the logged-in user using GetAllBookingsForUserAsync
		var bookings = await _bookingService.GetAllBookingsForUserAsync(currentUser.Id);

		if (bookings == null || !bookings.Any())
		{
			return NotFound("No bookings found for the current user.");
		}

		return Ok(bookings);
		// Return the bookings for the current user
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

[HttpDelete("{bookingId}")]
public async Task<IActionResult> DeleteBooking(int bookingId)
{
    // Retrieve the logged-in user's ID from the JWT token
    var userEmail = User.FindFirstValue(ClaimTypes.Email);
    if (string.IsNullOrEmpty(userEmail))
    {
        return Unauthorized(new { message = "User is not authenticated." });
    }

    var currentUser = await _userManager.FindByEmailAsync(userEmail);
    if (currentUser == null)
    {
        return NotFound(new { message = "User not found." });
    }

    // Fetch the booking to verify ownership
    var booking = await _bookingService.GetBookingByIdAsync(bookingId);
    if (booking == null)
    {
        return NotFound(new { message = "Booking not found." });
    }

    // Check if the logged-in user is the owner of the booking
    if (booking.UserId != currentUser.Id)
    {
        return BadRequest(new { message = "You are not authorized to delete this booking." });
    }

    // Proceed with deletion
    var (success, message) = await _bookingService.DeleteBookingByIdAsync(bookingId);
    if (!success)
    {
        return BadRequest(new { message });
    }

    return Ok(new { message });
}


}
