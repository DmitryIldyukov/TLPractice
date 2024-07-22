using CarFactory.Interfaces;
using CarFactory.Models.CarBrands;

namespace CarFactory.Models.CarModels;

public class M8 : ICarModel
{
    public M8( BMW carBrand )
    {
        CarBrand = carBrand;
    }

    public string Name => "M8";

    public ICarBrand CarBrand { get; init; }
}