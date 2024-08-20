using CarFactory.Models.Car;

namespace CarFactory.Services;

public interface ICarService
{
    IEnumerable<ICar> GetCars();
    ICar CreateCar();
}
