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
        private readonly IVehicleModelRepository _repository;
				  private readonly ApplicationDBContext _context;

        public VehicleModelController(IVehicleModelRepository repository, ApplicationDBContext context)
        {
            _repository = repository;
						 _context = context;
        }

      [HttpGet]
    public async Task<ActionResult<IEnumerable<VehicleModelDto>>> GetVehicleModels()
    {
        var vehicleModels = await _context.VehicleModels.ToListAsync();

        // Map to DTO
        var vehicleModelDtos = vehicleModels.Select(vm => new VehicleModelDto
        {
            VehicleModelId = vm.VehicleModelId,
            Make = vm.Make,
            Model = vm.Model,
            Year = vm.Year
        }).ToList();

        return Ok(vehicleModelDtos);
    }
       
    }
}
