using CarFactory.Models.CarBrands;
using CarFactory.Models.Enums;

namespace CarFactory.Models.CarModels;

public class Priora : ICarModel
{
    public string Name => "Приора";

    public EngineType EngineType => EngineType.ICE;

    public GearboxType GearboxType => GearboxType.Manual;

    public ICarBrand CarBrand => new Lada();
}