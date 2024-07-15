namespace CarFactory.Models.CarClasses;

public class Sedan : ICarClass
{
    public string Name => "Седан";

    public override string ToString()
    {
        return Name;
    }
}