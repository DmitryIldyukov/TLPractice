namespace CarFactory.Models.Colors;

public class Blue : IColor
{
    public string Name => "Синий";

    public override string ToString()
    {
        return Name;
    }
}