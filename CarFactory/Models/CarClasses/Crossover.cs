namespace CarFactory.Models.CarClasses;

public class Crossover : ICarClass
{
    public string Name => "Кроссовер";

    public override string ToString()
    {
        return Name;
    }
}
