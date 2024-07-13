using CarFactory.Models.CarModels;

namespace CarFactory.Services;

public interface IModelService
{
    IEnumerable<ICarModel> GetAllModels();
}
