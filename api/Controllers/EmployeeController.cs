namespace api.Controllers
{



using System.Threading.Tasks;
using api.Data;
using api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


	   [ApiController]
[Route("api/[controller]")]

    public class EmployeeController  : ControllerBase
    {
         private readonly ApplicationDBContext _context;


				  public EmployeeController(
            UserManager<AppUser> userManager,
           
            ApplicationDBContext context
           )
        {
            
            _context = context;
            
        }

		 // GET: api/employee
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _context.Employee.ToListAsync(); // Retrieves all Employee records
            return Ok(employees);
        }

        // GET: api/employee/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployee(int id)
        {
            var employee = await _context.Employee.FindAsync(id); // Retrieves a specific Employee record by ID
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }



    }
}