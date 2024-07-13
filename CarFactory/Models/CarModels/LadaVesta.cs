using CarFactory.Models.CarBrands;
using CarFactory.Models.Enums;

namespace CarFactory.Models.CarModels;

public class LadaVesta : ICarModel
{
    public string Name => throw new NotImplementedException();

    public EngineType EngineType => throw new NotImplementedException();

    public GearboxType GearboxType => throw new NotImplementedException();

    public ICarBrand CarBrand => throw new NotImplementedException();
}
