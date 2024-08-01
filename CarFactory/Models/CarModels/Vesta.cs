using CarFactory.Models.CarBrands;

namespace CarFactory.Models.CarModels;

public class Vesta : ICarModel
{
    public Vesta( Lada carBrand )
    {
        CarBrand = carBrand;
    }
    public string Name => "Веста";

    public ICarBrand CarBrand { get; init; }
}
