using CarFactory.Models.CarBrands;
using CarFactory.Models.CarClasses;
using CarFactory.Models.CarModels;
using CarFactory.Models.Cars;
using CarFactory.Models.Colors;
using CarFactory.Models.Engine;
using CarFactory.Models.GearBox;

namespace CarFactory.Storage;

public interface ICarStorage : ICarAdder
{
    ICarModel[] GetCarModels();
    ICarBrand[] GetCarBrands();
    IColor[] GetColors();
    ICarClass[] GetCarClasses();
    IEngine[] GetEngines();
    IGearBox[] GetGearBoxes();
    IEnumerable<ICar> GetCars();
}

public interface ICarAdder
{
    void AddCar( ICar car );
}