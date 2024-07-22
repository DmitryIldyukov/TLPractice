using CarFactory.Interfaces;
using CarFactory.Models.CarBrands;
using CarFactory.Models.CarClasses;
using CarFactory.Models.CarModels;
using CarFactory.Models.Colors;
using CarFactory.Models.Engine;
using CarFactory.Models.GearBox;

namespace CarFactory.Storage;

public class CarStorage : ICarStorage
{
    private readonly ICollection<ICarBrand> _carBrands = new List<ICarBrand>();
    private readonly ICollection<ICarModel> _carModels = new List<ICarModel>();
    private readonly ICollection<IColor> _colors = new List<IColor>();
    private readonly ICollection<ICarClass> _carClasses = new List<ICarClass>();
    private readonly ICollection<IEngine> _engines = new List<IEngine>();
    private readonly ICollection<IGearBox> _gearBoxes = new List<IGearBox>();
    private readonly ICollection<ICar> _cars = new List<ICar>();

    public CarStorage()
    {
        InitializeizeCarStorage();
    }

    private void InitializeizeCarStorage()
    {
        InitializeCarBrands();
        InitializeCarModels();
        InitializeColors();
        InitializeCarClasses();
        InitializeEngines();
        InitializeGearBoxes();
    }

    private void InitializeCarBrands()
    {
        _carBrands.Add( new Mercedes() );
        _carBrands.Add( new BMW() );
        _carBrands.Add( new Lada() );
    }

    private void InitializeCarModels()
    {
        _carModels.Add( new G63( _carBrands.OfType<Mercedes>().FirstOrDefault() ?? new Mercedes() ) );
        _carModels.Add( new Priora( _carBrands.OfType<Lada>().FirstOrDefault() ?? new Lada() ) );
        _carModels.Add( new Vesta( _carBrands.OfType<Lada>().FirstOrDefault() ?? new Lada() ) );
        _carModels.Add( new M3( _carBrands.OfType<BMW>().FirstOrDefault() ?? new BMW() ) );
        _carModels.Add( new M8( _carBrands.OfType<BMW>().FirstOrDefault() ?? new BMW() ) );
    }

    private void InitializeColors()
    {
        _colors.Add( new Black() );
        _colors.Add( new Blue() );
        _colors.Add( new White() );
        _colors.Add( new Red() );
    }

    private void InitializeCarClasses()
    {
        _carClasses.Add( new Crossover() );
        _carClasses.Add( new Hatchback() );
        _carClasses.Add( new Sedan() );
        _carClasses.Add( new Universal() );
    }

    private void InitializeEngines()
    {
        _engines.Add( new Diesel() );
        _engines.Add( new Petrol() );
    }

    private void InitializeGearBoxes()
    {
        _gearBoxes.Add( new Robot() );
        _gearBoxes.Add( new Manual() );
        _gearBoxes.Add( new Automatic() );
    }

    public IEnumerable<ICarBrand> GetCarBrands() => _carBrands;

    public IEnumerable<ICarModel> GetCarModels() => _carModels;

    public IEnumerable<IColor> GetColors() => _colors;

    public IEnumerable<ICarClass> GetCarClasses() => _carClasses;

    public IEnumerable<IEngine> GetEngines() => _engines;

    public IEnumerable<IGearBox> GetGearBoxes() => _gearBoxes;

    public IEnumerable<ICar> GetCars() => _cars;

    public void AddCar( ICar car ) => _cars.Add( car );
}
