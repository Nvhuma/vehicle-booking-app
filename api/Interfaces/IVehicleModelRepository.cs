
using api.Models;

namespace api.Interfaces
{
    public interface IVehicleModelRepository
    {
        Task<List<VehicleModel>> GetAllAsync();
       
    }
}