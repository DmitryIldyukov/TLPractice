namespace Gladiators.Models.Type;

public class Cavalry : IFighterType
{
    public string Name => "Конница";
    public int Health => 30;
    public int Strength => 20;
}