namespace CarFactory.Models.GearBox;

public class Robot : IGearBox
{
    public string Name => "Робот";

    public int AdditionalSpeed => 35;

    public int GearCount => 3;

    public override string ToString()
    {
        return Name;
    }
}
