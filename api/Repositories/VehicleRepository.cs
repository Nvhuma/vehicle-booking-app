using api.Data;
using api.Interfaces;
using api.Models;
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

        public async Task<IEnumerable<VehicleModel>> GetAllAsync()
        {
            return await _context.VehicleModels.ToListAsync();
        }

      
    }
}
