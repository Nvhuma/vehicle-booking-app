using api.Data;
using api.DTOs.VehicleModelDtos;
using api.Interfaces;
using api.Models;
using api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

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
			_vehicleRepo = vehicleRepo ;
			_context = context;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<VehicleModelDto>>> GetVehicleModels()
		{
			var vehicleModels = await _vehicleRepo.GetAllAsync();

			return Ok(vehicleModels);
		}

	}
}
