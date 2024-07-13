using CarFactory.Models.CarBrands;
using CarFactory.Models.CarClasses;
using CarFactory.Models.Enums;

namespace CarFactory.Models.CarModels;

public class TeslaRoadster : ICarModel
{
    public string Name => "Roadster";

    public EngineType EngineType => EngineType.Electronic;

    public GearboxType GearboxType => GearboxType.Automatic;

    public ICarBrand CarBrand => new Tesla();

    public ICarClass CarClass => new Sedan();
}