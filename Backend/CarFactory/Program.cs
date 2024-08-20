using CarFactory.Handler;
using CarFactory.Services;
using CarFactory.Storage;

namespace CarFactory;

internal class Program
{
    static void Main()
    {
        ICarStorage storage = new CarStorage();
        ICarService carService = new CarService( storage );
        ICarFactoryHandler carFactoryHandler = new CarFactoryHandler( carService );
        carFactoryHandler.Start();
    }
}