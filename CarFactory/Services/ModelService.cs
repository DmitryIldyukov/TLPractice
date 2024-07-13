using CarFactory.Models.CarModels;

namespace CarFactory.Services;

public class ModelService : IModelService
{
    private readonly static ICarModel[] _models = new ICarModel[]
    {
        new TeslaRoadster(),
    };

    public IEnumerable<ICarModel> GetAllModels()
    {
        return _models;
    }
}
