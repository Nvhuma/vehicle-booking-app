using api.DTOs.VehicleModelDtos;

public class VehicleModelDto
{
    public int VehicleModelId { get; set; }
    public string Make { get; set; }
    public string Model { get; set; }
    public int Year { get; set; }
    public string HorsepowerRange { get; set; }
    public string TorqueRange { get; set; }
    public int MaxTowingCapacity { get; set; }
    public string EmissionStandard { get; set; }

    // You can include navigation properties if needed, but avoid service prices
    public List<EngineTypeDto> EngineTypes { get; set; }
    public List<TransmissionTypeDto> TransmissionTypes { get; set; }
    public List<DriveTrainDto> DriveTrains { get; set; }
    public List<FuelTypeDto> FuelTypes { get; set; }
    public List<TrimLevelDto> TrimLevels { get; set; }
}