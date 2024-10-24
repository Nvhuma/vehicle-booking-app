
using api.Models;

namespace api.Interfaces
{
    public interface IVehicleModelRepository
    {
        Task<IEnumerable<VehicleModel>> GetAllAsync();
       
    }
}