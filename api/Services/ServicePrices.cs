


namespace api.Services
{
	using api.Data;
	using api.DTOs.AdminDtos;
	using Microsoft.EntityFrameworkCore;
	public class ServicePrices
	{
		private readonly ApplicationDBContext _context;

		public ServicePrices(ApplicationDBContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<ServicePriceDto>> GetServicePricesWithVehicleModelAsync()
		{
			var servicePrices = await _context.ServicePrices
					.Include(sp => sp.VehicleModel) // Ensure this navigation property is correctly set up in your model
					.Select(sp => new ServicePriceDto
					{
						Id = sp.Id,
						VehicleModelId = sp.VehicleModelId,
						Make = sp.VehicleModel.Make, // Adjust field names based on your entity properties
						Model = sp.VehicleModel.Model,
						HorsepowerRange = sp.VehicleModel.HorsepowerRange,
						TorqueRange = sp.VehicleModel.TorqueRange,
						MaxTowingCapacity = sp.VehicleModel.MaxTowingCapacity,
						EmissionStandard = sp.VehicleModel.EmissionStandard,
						Year = sp.VehicleModel.Year,
						ServiceTypeId = sp.ServiceTypeId,
						Price = sp.Price
					})
					.ToListAsync();

			return servicePrices;
		}
	}
}
