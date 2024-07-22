namespace CarFactory.Interfaces;

public interface ICar
{
    IColor Color { get; }
    ICarModel CarModel { get; }
    ICarClass CarClass { get; }
    IEngine Engine { get; }
    IGearBox GearBox { get; }
    bool IsLeftSideWheel { get; }
    int CalculateMaxSpeed();
    int GetNumberOfGears();
}
