using CarFactory.Interfaces;

namespace CarFactory.Storage;

public interface ICarAdder
{
    void AddCar( ICar car );
}
