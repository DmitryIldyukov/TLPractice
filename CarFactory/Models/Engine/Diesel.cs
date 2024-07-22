using CarFactory.Interfaces;

namespace CarFactory.Models.Engine;

public class Diesel : IEngine
{
    public string Name => "Дизельный";

    public int Horsepower => 190;

    public int GearCount => 4;
}
