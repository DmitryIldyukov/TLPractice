using CarFactory.Models.CarClasses;
using CarFactory.Models.CarModels;
using CarFactory.Models.Colors;

namespace CarFactory.Models.Cars;

public interface ICar
{
    IColor Color { get; }
    ICarModel CarModel { get; }
    ICarClass CarClass { get; }
    bool IsLeftSideWheel { get; }
    int CalculateMaxSpeed();
    int GetNumberOfGears();
}
