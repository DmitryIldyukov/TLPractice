using CarFactory.Models.Cars;

namespace CarFactory.Storage;

public interface ICarAdder
{
    void AddCar( ICar car );
}
