namespace CarFactory.Models.GearBox;

public interface IGearBox
{
    string Name { get; }
    int AdditionalSpeed { get; }
    int GearCount { get; }
}
