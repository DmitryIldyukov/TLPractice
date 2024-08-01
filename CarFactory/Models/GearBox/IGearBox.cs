using CarFactory.Interfaces;

namespace CarFactory.Models.GearBox;

public interface IGearBox : INamedInterface
{
    int AdditionalSpeed { get; }
    int GearCount { get; }
}
