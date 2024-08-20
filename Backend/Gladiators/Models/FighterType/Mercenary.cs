namespace Gladiators.Models.Type;

public class Mercenary : IFighterType
{
    public string Name => "Наемник";
    public int Health => 20;
    public int Strength => 25;
}
