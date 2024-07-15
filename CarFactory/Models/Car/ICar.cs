﻿using CarFactory.Models.CarClasses;
using CarFactory.Models.CarModels;
using CarFactory.Models.Colors;
using CarFactory.Models.Engine;
using CarFactory.Models.GearBox;

namespace CarFactory.Models.Cars;

public interface ICar
{
    IColor Color { get; }
    ICarModel CarModel { get; }
    ICarClass CarClass { get; }
    IEngine Engine { get; }
    IGearBox GearBox { get; }
    bool IsLeftSideWheel { get; }
    int CalculateMaxSpeed();
    int GetNumberOfGears();
}
