using CarFactory.Interfaces;

namespace CarFactory.Models.Engine;

public interface IEngine : INamedInterface
{
    int Horsepower { get; }
    int GearCount { get; }
}
