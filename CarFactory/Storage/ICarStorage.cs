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
    IEnumerable<ICarModel> GetCarModels();
    IEnumerable<ICarBrand> GetCarBrands();
    IEnumerable<IColor> GetColors();
    IEnumerable<ICarClass> GetCarClasses();
    IEnumerable<IEngine> GetEngines();
    IEnumerable<IGearBox> GetGearBoxes();
    IEnumerable<ICar> GetCars();
}