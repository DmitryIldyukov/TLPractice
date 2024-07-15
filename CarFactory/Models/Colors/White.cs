namespace CarFactory.Models.Colors;

public class White : IColor
{
    public string Name => "Белый";

    public override string ToString()
    {
        return Name;
    }
}
