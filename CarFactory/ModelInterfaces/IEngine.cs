namespace CarFactory.Interfaces;

public interface IEngine : INamedInterface
{
    int Horsepower { get; }
    int GearCount { get; }
}
