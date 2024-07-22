using CarFactory.Interfaces;
using CarFactory.Models.CarBrands;

namespace CarFactory.Models.CarModels;

public class G63 : ICarModel
{
    public G63( Mercedes carBrand )
    {
        CarBrand = carBrand;
    }

    public string Name => "G63";

    public ICarBrand CarBrand { get; init; }
}
