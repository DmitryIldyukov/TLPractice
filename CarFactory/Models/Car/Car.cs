using CarFactory.Interfaces;

namespace CarFactory.Models.Car;

public class Car : ICar
{
    public Car(
        ICarModel carModel, 
        ICarClass carClass, 
        IEngine engine, 
        IGearBox gearBox, 
        IColor color, 
        bool isLeftSideWheel )
    {
        CarModel = carModel;
        CarClass = carClass;
        Engine = engine;
        GearBox = gearBox;
        Color = color;
        IsLeftSideWheel = isLeftSideWheel;
    }

    public IColor Color { get; init; }

    public ICarModel CarModel { get; init; }

    public ICarClass CarClass { get; init; }

    public IEngine Engine { get; init; }

    public IGearBox GearBox { get; init; }

    public bool IsLeftSideWheel { get; init; }

    public int CalculateMaxSpeed() => ( int )( Engine.Horsepower * 1.2 + GearBox.AdditionalSpeed);

    public int GetNumberOfGears() => int.Min( Engine.GearCount + GearBox.GearCount, 6 );

    public override string ToString()
    {
        string carInfo = $"------ {CarModel.CarBrand.Name} {CarModel.Name} ------\n" +
                         $"Кузов: {CarClass.Name}\n" +
                         $"Цвет: {Color.Name}\n" +
                         $"Двигатель: {Engine.Name} \n" +
                         $"Коробка передач: {GearBox.Name}\n" +
                         $"Расположение руля: {( IsLeftSideWheel ? "Слева" : "Справа" )}\n" +
                         $"Максимальная скорость: {CalculateMaxSpeed()}\n" +
                         $"Количество передач: {GetNumberOfGears()}\n";

        return carInfo;
    }
}
