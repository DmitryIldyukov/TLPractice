namespace CarFactory.Interfaces;

public interface IGearBox : INamedInterface
{
    int AdditionalSpeed { get; }
    int GearCount { get; }
}
