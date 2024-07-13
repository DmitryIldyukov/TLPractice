using CarFactory.Models.CarBrands;
using CarFactory.Models.CarClasses;
using CarFactory.Models.Enums;

namespace CarFactory.Models.CarModels;

public interface ICarModel
{
    string Name { get; }
    EngineType EngineType { get; }
    GearboxType GearboxType { get; }
    ICarBrand CarBrand { get; }
}
