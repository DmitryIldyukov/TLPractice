using CarFactory.Interfaces;
using CarFactory.Models.CarBrands;

namespace CarFactory.Models.CarModels;

public class M3 : ICarModel
{
    public M3( BMW carBrand )
    {
        CarBrand = carBrand;
    }

    public string Name => "M3";

    public ICarBrand CarBrand { get; init; }
}