using CarFactory.Models.Car;

namespace CarFactory.Storage;

public interface ICarAdder
{
    void AddCar( ICar car );
}
