using api.Data;
using api.DTOs.VehicleModelDtos;
using api.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace api.Repositories
{
    public class VehicleModelRepository : IVehicleModelRepository
	{
		private readonly ApplicationDBContext _context;

		public VehicleModelRepository(ApplicationDBContext context)
		{
			_context = context;
		}

public async Task<List<VehicleModelDto>> GetAllAsync()
{
    var vehicleModels = await _context.VehicleModels
        .Include(vm => vm.VehicleModelEngineTypes)
            .ThenInclude(vme => vme.EngineType)
        .Include(vm => vm.VehicleModelTransmissionTypes)
            .ThenInclude(vmt => vmt.TransmissionType)
        .Include(vm => vm.VehicleModelDriveTrains)
            .ThenInclude(vmd => vmd.DriveTrain)
        .Include(vm => vm.VehicleModelFuelTypes)
            .ThenInclude(vmf => vmf.FuelType)
        .Include(vm => vm.VehicleModelTrimLevels)
            .ThenInclude(vmt => vmt.TrimLevel)
        .AsSplitQuery()
        .Select(vm => new VehicleModelDto
				
        {
            VehicleModelId = vm.VehicleModelId,
            Make = vm.Make,
            Model = vm.Model,
            Year = vm.Year,
            HorsepowerRange = vm.HorsepowerRange,
            TorqueRange = vm.TorqueRange,
            MaxTowingCapacity = vm.MaxTowingCapacity,
            EmissionStandard = vm.EmissionStandard,
            EngineTypes = vm.VehicleModelEngineTypes
                .Select(vme => new EngineTypeDto
                {
                    EngineTypeId = vme.EngineTypeId,
                    EngineTypeName = vme.EngineType.EngineTypeName
                }).ToList(),
            TransmissionTypes = vm.VehicleModelTransmissionTypes
                .Select(vmt => new TransmissionTypeDto
                {
                    TransmissionTypeId = vmt.TransmissionTypeId,
                    TransmissionTypeName = vmt.TransmissionType.TransmissionTypeName
                }).ToList(),
            DriveTrains = vm.VehicleModelDriveTrains
                .Select(vmd => new DriveTrainDto
                {
                    DriveTrainId = vmd.DriveTrainId,
                    DriveTrainName = vmd.DriveTrain.DriveTrainName
                }).ToList(),
            FuelTypes = vm.VehicleModelFuelTypes
                .Select(vmf => new FuelTypeDto
                {
                    FuelTypeId = vmf.FuelTypeId,
                    FuelTypeName = vmf.FuelType.FuelTypeName
                }).ToList(),
            TrimLevels = vm.VehicleModelTrimLevels
                .Select(vmt => new TrimLevelDto
                {
                    TrimLevelId = vmt.TrimLevelId,
                    TrimLevelName = vmt.TrimLevel.TrimLevelName
                }).ToList()
        })
        .ToListAsync();  // defer execution

    return vehicleModels;
}

	}
}
