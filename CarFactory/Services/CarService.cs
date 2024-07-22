using CarFactory.Helpers;
using CarFactory.Models.Car;
using CarFactory.Models.CarBrands;
using CarFactory.Models.CarClasses;
using CarFactory.Models.CarModels;
using CarFactory.Models.Cars;
using CarFactory.Models.Colors;
using CarFactory.Models.Engine;
using CarFactory.Models.GearBox;
using CarFactory.Storage;

namespace CarFactory.Services;

public class CarService : ICarService
{
    private readonly ICarStorage _carStorage;

    public CarService( ICarStorage carStorage )
    {
        _carStorage = carStorage;
    }

    public ICar CreateCar()
    {
        ICarBrand carBrand = ChooseItem( _carStorage.GetCarBrands(), "марок автомобилей" );
        ICarModel carModel = ChooseCarModel( carBrand );
        IEngine engine = ChooseItem( _carStorage.GetEngines(), "двигателей" );
        IGearBox gearBox = ChooseItem( _carStorage.GetGearBoxes(), "коробок передач" );
        ICarClass carClass = ChooseItem( _carStorage.GetCarClasses(), "типов кузовов" );
        IColor color = ChooseItem( _carStorage.GetColors(), "цветов" );
        bool isLeftSideWheel = ChooseWheelSide();

        var car = new Car( carModel, carClass, engine, gearBox, color, isLeftSideWheel );
        _carStorage.AddCar( car );

        return car;
    }

    public IEnumerable<ICar> GetCars() => _carStorage.GetCars();

    private T ChooseItem<T>( IEnumerable<T> items, string type ) where T : class
    {
        List<T> itemList = items.ToList();

        if ( itemList.Count == 0 )
        {
            throw new Exception( $"Нет доступных {type}" );
        }

        Console.WriteLine( $"Выберите из доступных {type}:" );

        return ConsoleHelper.ChooseItemByIndex( itemList );
    }

    private ICarModel ChooseCarModel( ICarBrand brand )
    {
        List<ICarModel> availableModels = _carStorage.GetCarModels().Where( m => m.CarBrand == brand ).ToList();

        if ( availableModels.Count() == 0 )
        {
            throw new Exception( "Нет доступных моделей авто." );
        }

        Console.WriteLine( "Выберите модель автомобиля:" );

        return ConsoleHelper.ChooseItemByIndex( availableModels );
    }

    private bool ChooseWheelSide()
    {
        Console.Write( "С какой стороны руль (l - слева/r - справа): " );
        while ( true )
        {
            string side = Console.ReadLine().ToLower().Trim();

            if ( side == "r" || side == "l" )
            {
                return side == "l";
            }

            Console.Write( "Неверный ввод. Введите 'l' для левой стороны или 'r' для правой: " );
        }
    }
}
