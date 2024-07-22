using CarFactory.Interfaces;

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