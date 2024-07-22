using CarFactory.Interfaces;
using CarFactory.Models.CarBrands;

namespace CarFactory.Models.CarModels;

public class Priora : ICarModel
{
    public Priora( Lada carBrand )
    {
        CarBrand = carBrand;
    }

    public string Name => "Приора";

    public ICarBrand CarBrand { get; init; }
}