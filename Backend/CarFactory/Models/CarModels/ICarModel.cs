using CarFactory.Interfaces;
using CarFactory.Models.CarBrands;

namespace CarFactory.Models.CarModels;

public interface ICarModel : INamedInterface
{
    ICarBrand CarBrand { get; }
}
