using CarFactory.Models.Car;
using CarFactory.Models.Cars;

namespace CarFactory.Services;

public class CarService : ICarService
{
    private readonly static IEnumerable<ICar> _cars = new List<ICar>();
    private readonly IModelService _modelService;

    public CarService(IModelService modelService)
    {
        _modelService = modelService;
    }

    public ICar CreateCar()
    {


        ICar car = new Car();
        return car;
    }

    public IEnumerable<ICar> GetCars()
    {
        return _cars;
    }
}
