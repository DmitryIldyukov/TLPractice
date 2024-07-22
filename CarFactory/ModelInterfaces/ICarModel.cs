namespace CarFactory.Interfaces;

public interface ICarModel : INamedInterface
{
    ICarBrand CarBrand { get; }
}
