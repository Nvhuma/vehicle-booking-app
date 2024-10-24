using System.Security.Claims;
using api.DTOs.BookingsDtos;
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
    private readonly UserManager<AppUser> _userManager;

    public BookingsController(BookingService bookingService, UserManager<AppUser> userManager)
    {
        _bookingService = bookingService;
        _userManager = userManager;
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
   

		var  servicePrice  = await _bookingService.GetServicePriceAsync( vehicleModel.VehicleModelId,int.Parse(request.ServiceType));

    if (servicePrice == null)
    {
        return BadRequest("No price available for the selected vehicle model and service type.");
    }

    // Create the booking object
    var booking = new Booking
    {
        UserId = currentUser.Id,  // Set the UserId to the current user's ID
        VehicleModelId = vehicleModel.VehicleModelId, // Link the VehicleModel to the Booking
        ServiceType = request.ServiceType,
        DesiredDateTime = request.DesiredDateTime,
        EmployeeId = request.EmployeeId,
        AdditionalNotes = request.AdditionalNotes,
        BookingStatus = "Pending",
        Price = servicePrice.Price  // Track the price from the ServicePrices table
    };

    // Persist the booking
    var createdBooking = await _bookingService.CreateBooking(booking);

    return Ok(new
    {
        BookingId = createdBooking.BookingId,
        Message = "Booking successfully created",
        createdBooking.BookingStatus,
        Price = createdBooking.Price  // Return the price in the response
    });
}

    
    }

