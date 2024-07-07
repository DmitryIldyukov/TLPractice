namespace Gladiators.Models.Type;

public interface IFighterType
{
    string Name { get; }
    int Health { get; }
    int Strength { get; }
}