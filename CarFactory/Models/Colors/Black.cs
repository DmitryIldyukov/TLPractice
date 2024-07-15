namespace CarFactory.Models.Colors;

public class Black : IColor
{
    public string Name => "Черный";

    public override string ToString()
    {
        return Name;
    }
}
