using CarFactory.Models.CarBrands;

namespace CarFactory.Models.CarModels;

public interface ICarModel
{
    string Name { get; }
    ICarBrand CarBrand { get; }
}
