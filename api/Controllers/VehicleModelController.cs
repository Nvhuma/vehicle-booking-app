using api.Data;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class VehicleModelController : ControllerBase
	{
		private readonly IVehicleModelRepository _vehicleRepo;
		private readonly ApplicationDBContext _context;

		public VehicleModelController(IVehicleModelRepository vehicleRepo, ApplicationDBContext context)
		{
			_vehicleRepo = vehicleRepo;
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<List<VehicleModelDto>>> GetVehicleModels()
		{
			var vehicleModels = await _vehicleRepo.GetAllAsync();


			return Ok(vehicleModels);

			
		}

	}
}
