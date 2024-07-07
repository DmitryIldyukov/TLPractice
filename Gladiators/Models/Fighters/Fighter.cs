using Gladiators.Models.Armors;
using Gladiators.Models.Races;
using Gladiators.Models.Type;
using Gladiators.Models.Weapons;

namespace Gladiators.Models.Fighters;

public class Fighter : IFighter
{
    public IFighterType FighterType { get; }

    public IRace Race { get; }

    public IWeapon Weapon { get; }

    public IArmor Armor { get; }

    public string Name { get; }

    public int CurrentHealth { get; private set; }

    public int ArmorPoints { get; private set; }

    public int MaxHealth { get; }

    public bool IsAlive => CurrentHealth > 0;

    public Fighter( string name,
        IFighterType fighterType,
        IRace race,
        IWeapon weapon,
        IArmor armor )
    {
        Name = name;
        FighterType = fighterType;
        Race = race;
        Weapon = weapon;
        Armor = armor;
        MaxHealth = Race.Health + FighterType.Health;
        CurrentHealth = MaxHealth;
        ArmorPoints = Race.Armor + Armor.Armor;
    }

    public int CalculateDamage() => Race.Strength + FighterType.Strength + Weapon.Damage;

    public int TakeDamage( int opponentDamage )
    {
        int startHealth = CurrentHealth;
        int newHealth = CurrentHealth - ( Math.Max( opponentDamage - ArmorPoints, 1 ) );

        if ( newHealth < 0 )
        {
            newHealth = 0;
        }

        CurrentHealth = newHealth;
        int damageDealt = startHealth - CurrentHealth;

        return damageDealt;
    }

    public void Revive() => CurrentHealth = MaxHealth;

    public override string ToString()
    {
        return $"Боец {Name}:\n" +
            $"Класс: {FighterType.Name}\n" +
            $"Раса: {Race.Name}\n" +
            $"Оружие: {Weapon.Name}\n" +
            $"Броня: {Armor.Name}\n" +
            $"Максимальное здоровье: {MaxHealth}\n" +
            $"Текущее здоровье: {CurrentHealth}\n" +
            $"Броня: {ArmorPoints}\n" +
            $"Урон: {CalculateDamage()}\n" +
            $"Состояние здоровья: {( IsAlive ? "Жив" : "Мертв" )}";
    }
}
