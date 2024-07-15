namespace CarFactory.Models.CarBrands;

public class BMW : ICarBrand
{
    public string Name => "BMW";

    public override string ToString()
    {
        return Name;
    }
}
