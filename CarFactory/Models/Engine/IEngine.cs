using CarFactory.Models.Enums;

namespace CarFactory.Models.Engine;

public interface IEngine
{
    string Name { get; }
    int MaxSpeed { get; }
    int GearCount { get; }
    EngineType EngineType { get; } 
}
