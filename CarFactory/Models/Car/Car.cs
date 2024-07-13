using CarFactory.Models.CarClasses;
using CarFactory.Models.CarModels;
using CarFactory.Models.Cars;
using CarFactory.Models.Colors;

namespace CarFactory.Models.Car;

public class Car : ICar
{
    public IColor Color => throw new NotImplementedException();

    public ICarModel CarModel => throw new NotImplementedException();

    public ICarClass CarClass => throw new NotImplementedException();

    public bool IsLeftSideWheel => throw new NotImplementedException();
    public int CalculateMaxSpeed() => throw new NotImplementedException();
}
