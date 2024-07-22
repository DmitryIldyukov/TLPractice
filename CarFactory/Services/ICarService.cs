using CarFactory.Interfaces;

namespace CarFactory.Services;

public interface ICarService
{
    IEnumerable<ICar> GetCars();
    ICar CreateCar();
}
