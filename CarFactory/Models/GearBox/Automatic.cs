namespace CarFactory.Models.GearBox;

public class Automatic : IGearBox
{
    public string Name => "Автомат";

    public int AdditionalSpeed => 40;

    public int GearCount => 2;
}
