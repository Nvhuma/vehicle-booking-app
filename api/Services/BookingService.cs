using api.Data;
using api.DTOs.BookingsDtos;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Services
{
	public class BookingService
	{
		private readonly ApplicationDBContext _context;
		    private readonly ILogger<BookingService> _logger;

		public BookingService(ApplicationDBContext context,  ILogger<BookingService> logger)
		{
			_context = context;
			 _logger = logger;

		}

		public async Task<(bool IsAvailable, string Message)> CheckAvailability(string serviceType, DateTime desiredDateTime, string employeeId = null)
		{
			// Check for conflicts for the selected service type
			var conflictingServiceBooking = await _context.Bookings
					.AnyAsync(b => b.ServiceType == serviceType && b.DesiredDateTime == desiredDateTime);

			if (conflictingServiceBooking)
			{
				return (false, "Time slot is unavailable for the selected service.");
			}

			// If an employee ID is provided, check for conflicts with that specific employee
			if (!string.IsNullOrEmpty(employeeId))
			{
				var employeeConflict = await _context.Bookings
						.AnyAsync(b => b.EmployeeId == employeeId && b.DesiredDateTime == desiredDateTime && b.ServiceType == serviceType); // you need to fix here .. same service same employee ?? 

				if (employeeConflict)
				{
					return (false, "The selected employee is not available at the requested time for this service.");
				}


				// Optional: Check if the employee is available for any other service at that time
				var employeeAvailableForOtherServices = await _context.Bookings
						.AnyAsync(b => b.EmployeeId == employeeId && b.DesiredDateTime == desiredDateTime);

				if (employeeAvailableForOtherServices)
				{
					// You could return a message stating that the employee is booked for another service

					return (false, "Selected employee is not available at the requested time.");

				}
			}

			return (true, "Time slot is available.");

		}

		public async Task<Booking> CreateBooking(Booking booking)

		{
			_context.Bookings.Add(booking);
			await _context.SaveChangesAsync();
			return booking;
		}

		public async Task<VehicleModel> GetVehicleModelAsync(int vehicleModelId)
		{
			// Retrieve the vehicle model by ID from the database
			var vehicleModel = await _context.VehicleModels.FindAsync(vehicleModelId);

			if (vehicleModel == null)
			{
				throw new Exception($"VehicleModel with ID {vehicleModelId} not found.");
			}

			return vehicleModel;
		}

		public async Task<ServicePrice> GetServicePriceAsync(int vehicleModelId, int serviceTypeId)
		{
			// Retrieve the service price for the given vehicle model and service type
			var servicePrice = await _context.ServicePrices
					.FirstOrDefaultAsync(sp => sp.VehicleModelId == vehicleModelId && sp.ServiceTypeId == serviceTypeId);

			if (servicePrice == null)
			{
				throw new Exception($"No service price found for VehicleModelId {vehicleModelId} and ServiceTypeId {serviceTypeId}.");
			}

			return servicePrice;
		}
		
		//method to retrieve a booking by ID 
		public async Task<Booking> GetBookingByIdAsync(int BookingId)
		{
			 try
			 {
				 return await _context.Bookings.FindAsync(BookingId);
			 }
			  catch (Exception ex)
				{
					  _logger.LogError(ex, $"Error retrieving booking with ID {BookingId}");
						throw; 
				}
		}

		// METHOD TO DELETE A BOOKING 

		public async Task<bool> DeleteBookingByIdAsync( int BookingId)
		{
			   try 
				 {
					 var booking = await _context.Bookings.FindAsync(BookingId);
					 if (booking == null)
					 {
						 _logger.LogWarning($"Attempted to delete a non-existing booking with ID {BookingId}");
						 return false; //when booking is not found 
					 }

					 // business logic to check and ensure the booking is complete or not canceled 
					 if (booking.BookingStatus == "Completed" || booking.BookingStatus == "Canceled")
					 {
						 _logger.LogWarning($"Attempted to delete a booking with ID {BookingId} that is {booking.BookingStatus}");
						 return false; //if booking is not completed

					 }

					 _context.Bookings.Remove(booking);
					 await _context.SaveChangesAsync();

					 return true; //booking canceled
				 }
				  catch (Exception ex)
					{
						 _logger.LogError(ex, $"Error deleting booking with ID {BookingId}");
						 throw;
					}
		}

 // method for getting bookings for a particular user 
 public async Task<IEnumerable<Booking>> GetAllBookingsForUserAsync( string UserId)
 {
	   return await _context.Bookings
		   .Where(b => b.UserId == UserId) // filter by user ID
            .ToListAsync(); // retrieve asynchronously
		
 }

	// update 

	public async Task<(bool Success, string Message)> UpdateBookingAsync(int BookingId, BookingRequestModel requestModel)
	{
		 //find the booking by id 
		 var booking = await _context.Bookings.FindAsync(BookingId);
		 if (booking == null)
		 {
			  return (false, "Booking not found");
		 }

		 // Check if the booking is scheduled within the next 12 hours
    var timeDifference = booking.DesiredDateTime - DateTime.UtcNow;
    if (timeDifference.TotalHours < 12)
    {
        return (false, "Booking cannot be updated less than 12 hours before the scheduled time.");
    }
		// Update the booking fields
    booking.ServiceType = requestModel.ServiceType;
    booking.DesiredDateTime = requestModel.DesiredDateTime;
    booking.EmployeeId = requestModel.EmployeeId;
    booking.AdditionalNotes = requestModel.AdditionalNotes;

    // Save changes
    try
    {
        await _context.SaveChangesAsync();
        return (true, "Booking successfully updated.");
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, $"Error updating booking with ID {BookingId}");
        return (false, "An error occurred while updating the booking.");
    }


	}

		internal async Task UpdateBookingAsync(Booking booking)
		{
			throw new NotImplementedException();
		}
	}
}

