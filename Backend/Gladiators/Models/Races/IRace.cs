namespace Gladiators.Models.Races;

public interface IRace
{
    string Name { get; }
    int Health { get; }
    int Strength { get; }
    int Armor { get; }
}
