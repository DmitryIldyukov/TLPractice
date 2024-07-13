using CarFactory.Models.CarBrands;
using CarFactory.Models.Enums;

namespace CarFactory.Models.CarModels;

public class BMWM3 : ICarModel
{
    public string Name => "M3";

    public EngineType EngineType => EngineType.ICE;

    public GearboxType GearboxType => GearboxType.Automatic;

    public ICarBrand CarBrand => new BMW();
}