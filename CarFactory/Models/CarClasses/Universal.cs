namespace CarFactory.Models.CarClasses;

public class Universal : ICarClass
{
    public string Name => "Универсал";

    public override string ToString()
    {
        return Name;
    }
}
