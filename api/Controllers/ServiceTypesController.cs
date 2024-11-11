
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace api.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceTypesController : ControllerBase
    {
       	private readonly ApplicationDBContext _context;// Replace with your actual DbContext
 
        public ServiceTypesController(ApplicationDBContext  context)
        {
            _context = context;
        }

        // GET: api/ServiceTypes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceType>>> GetServiceTypes()
        {
            var serviceTypes = await _context.ServiceTypes.ToListAsync();
            return Ok(serviceTypes); // Returning the list of service types
        }
    }
}


