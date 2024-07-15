namespace CarFactory.Models.Engine;

public interface IEngine
{
    string Name { get; }
    int Horsepower { get; }
    int GearCount { get; }
}
