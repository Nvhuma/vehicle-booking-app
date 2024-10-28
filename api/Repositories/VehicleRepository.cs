using api.Data;
using api.Interfaces;
using api.Models;
using Azure;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace api.Repositories
{
	public class VehicleModelRepository : IVehicleModelRepository
	{
		private readonly ApplicationDBContext _context;

		public VehicleModelRepository(ApplicationDBContext context)
		{
			_context = context;
		}

		public async Task<List<VehicleModel>> GetAllAsync()
		{
			var vehicleModelWithDetails = await _context.VehicleModels
    .Include(vm => vm.VehicleModelEngineTypes)
        .ThenInclude(vme => vme.EngineType)
    .Include(vm => vm.VehicleModelTransmissionTypes)
        .ThenInclude(vmt => vmt.TransmissionType)
    .Include(vm => vm.VehicleModelDriveTrains)
        .ThenInclude(vmd => vmd.DriveTrain)
    
		.ToListAsync();  // defer execution

		return vehicleModelWithDetails;

		}

	}
}
