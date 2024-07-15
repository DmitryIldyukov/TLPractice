using CarFactory.Models.Cars;
using CarFactory.Services;

namespace CarFactory.Handler;

public class CarFactoryHandler : ICarFactoryHandler
{
    private readonly ICarService _carService;

    public CarFactoryHandler( ICarService carService )
    {
        _carService = carService;
    }

    public void Start()
    {
        ShowGreeting();
        bool isExit = false;
        while ( !isExit )
        {
            ShowMenu();
            string input = Console.ReadLine().ToLower().Trim();
            switch ( input )
            {
                case "1":
                    try
                    {
                        CreateCar();
                    }
                    catch ( Exception e )
                    {
                        Console.WriteLine( $"Произошла ошибка. {e.Message}" );
                    }
                    break;
                case "2":
                    ShowCarsInformation();
                    break;
                case "exit":
                    isExit = true;
                    Console.WriteLine( "До свидания!" );
                    break;
            }
        }
    }

    private void ShowGreeting()
    {
        Console.WriteLine( "-------Добро пожаловать на фабрику машин!-------" );
        Console.WriteLine( "Здесь ты сможешь собрать машину. И помечтать о ней..." );
    }

    private void ShowMenu()
    {
        Console.WriteLine( "Доступные команды:" );
        Console.WriteLine( "1 - Создать автомобиль" );
        Console.WriteLine( "2 - Показать информацию об автомобилях" );
        Console.WriteLine( "exit - Я намечтался (Выход)" );
        Console.Write( "Ввод: " );
    }

    private void CreateCar()
    {
        ICar car = _carService.CreateCar();
        Console.WriteLine( $"Автомобиль {car.CarModel.CarBrand.Name} {car.CarModel.Name} успешно создан!" );
    }

    private void ShowCarsInformation()
    {
        List<ICar> cars = _carService.GetCars().ToList();

        if ( cars.Count == 0 )
        {
            Console.WriteLine( "Список автомобилей пуст." );
            return;
        }

        Console.WriteLine( "Список автомобилей:" );
        foreach ( ICar car in cars )
        {
            Console.WriteLine( car );
        }
    }
}
