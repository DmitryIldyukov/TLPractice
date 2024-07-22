using CarFactory.Interfaces;

namespace CarFactory.Models.GearBox;

public class Manual : IGearBox
{
    public string Name => "Механическая";

    public int AdditionalSpeed => 20;

    public int GearCount => 3;
}
