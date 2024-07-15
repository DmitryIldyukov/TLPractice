namespace CarFactory.Models.CarBrands;

public class Lada : ICarBrand
{
    public string Name => "LADA";

    public override string ToString()
    {
        return Name;
    }
}