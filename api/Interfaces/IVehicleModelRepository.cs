


namespace api.Interfaces
{
	using api.Models;
	public interface IVehicleModelRepository
	{
		Task<List<VehicleModelDto>> GetAllAsync();

	}
}