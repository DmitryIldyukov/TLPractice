namespace CarFactory.Models.CarBrands;

public class Mercedes : ICarBrand
{
    public string Name => "Mercedes";

    public override string ToString()
    {
        return Name;
    }
}