namespace CarFactory.Models.Engine;

public class Petrol : IEngine
{
    public string Name => "Бензиновый";

    public int Horsepower => 220;

    public int GearCount => 2;
}
