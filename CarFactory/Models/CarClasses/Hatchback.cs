namespace CarFactory.Models.CarClasses;

public class Hatchback : ICarClass
{
    public string Name => "Hatchback";

    public override string ToString()
    {
        return Name;
    }
}
