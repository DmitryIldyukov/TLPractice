using CarFactory.Handler;
using CarFactory.Services;

namespace CarFactory;

internal class Program
{
    static void Main()
    {
        IModelService carModel = new ModelService();
        ICarService carService = new CarService(carModel);
        ICarFactoryHandler carFactoryHandler = new CarFactoryHandler( carService );
        carFactoryHandler.Start();
    }
}