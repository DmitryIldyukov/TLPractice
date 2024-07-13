using CarFactory.Models.Cars;

namespace CarFactory.Services;

public interface ICarService
{
    IEnumerable<ICar> GetCars();
    ICar CreateCar();
}
