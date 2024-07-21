using Gladiators.Models.Armors;
using Gladiators.Models.Races;
using Gladiators.Models.Type;
using Gladiators.Models.Weapons;

namespace Gladiators.Models.Fighters;

public interface IFighter
{
    IFighterType FighterType { get; }
    IRace Race { get; }
    IWeapon Weapon { get; }
    IArmor Armor { get; }
    string Name { get; }
    int CurrentHealth { get; }
    int ArmorPoints { get; }
    int MaxHealth { get; }
    bool IsAlive { get; }
    int Strength { get; }
    int TakeDamage( int damage );
    int CalculateDamage();
    void Revive();
}
