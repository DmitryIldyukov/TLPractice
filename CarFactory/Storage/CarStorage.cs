using CarFactory.Models.CarBrands;
using CarFactory.Models.CarClasses;
using CarFactory.Models.CarModels;
using CarFactory.Models.Cars;
using CarFactory.Models.Colors;
using CarFactory.Models.Engine;
using CarFactory.Models.GearBox;

namespace CarFactory.Storage;

public class CarStorage : ICarStorage
{
    private static ICarBrand[] _carBrands;
    private static ICarModel[] _carModels;
    private static IColor[] _colors;
    private static ICarClass[] _carClasses;
    private static IEngine[] _engines;
    private static IGearBox[] _gearBoxes;

    public CarStorage()
    {
        InitialCarBrands();
        InitialCarModels();
        InitialColors();
        InitialCarClasses();
        InitialEngines();
        InitialGearBoxes();
    }

    private void InitialCarBrands()
    {
        _carBrands = new ICarBrand[]
        {
            new Mercedes(),
            new BMW(),
            new Lada()
        };
    }

    private void InitialCarModels()
    {
        _carModels = new ICarModel[]
        {
            new G63(_carBrands.OfType<Mercedes>().FirstOrDefault() ?? new Mercedes()),
            new Priora(_carBrands.OfType<Lada>().FirstOrDefault() ?? new Lada()),
            new Vesta(_carBrands.OfType<Lada>().FirstOrDefault() ?? new Lada()),
            new M3(_carBrands.OfType<BMW>().FirstOrDefault() ?? new BMW()),
            new M8(_carBrands.OfType<BMW>().FirstOrDefault() ?? new BMW())
        };
    }

    private void InitialColors()
    {
        _colors = new IColor[]
        {
            new Black(),
            new Blue(),
            new White(),
            new Red(),
        };
    }

    private void InitialCarClasses()
    {
        _carClasses = new ICarClass[]
        {
            new Crossover(),
            new Hatchback(),
            new Sedan(),
            new Universal(),
        };
    }

    private void InitialEngines()
    {
        _engines = new IEngine[]
       {
            new Diesel(),
            new Petrol(),
       };
    }

    private void InitialGearBoxes()
    {
        _gearBoxes = new IGearBox[]
        {
            new Robot(),
            new Manual(),
            new Automatic(),
        };
    }

    private static List<ICar> _cars = new List<ICar>();

    public ICarBrand[] GetCarBrands() => _carBrands;

    public ICarModel[] GetCarModels() => _carModels;

    public IColor[] GetColors() => _colors;

    public ICarClass[] GetCarClasses() => _carClasses;

    public IEngine[] GetEngines() => _engines;

    public IGearBox[] GetGearBoxes() => _gearBoxes;

    public IEnumerable<ICar> GetCars() => _cars;

    public void AddCar( ICar car ) => _cars.Add( car );
}
