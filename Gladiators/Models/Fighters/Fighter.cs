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

    public int Strength => Race.Strength + FighterType.Strength + Weapon.Damage;

    public bool IsAlive => CurrentHealth > 0;

    public Fighter(
        string name,
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

    public int CalculateDamage()
    {
        const double MinMultiplierDamage = 0.80;
        const double MaxMultiplierDamage = 1.10;
        const int CriticalPercentChance = 25;

        double attackMultiplier = ( double )Random.Shared.Next( ( int )( MinMultiplierDamage * 100 ), ( int )( MaxMultiplierDamage * 100 + 1 ) ) / 100;
        int fighterDamage = ( int )( Strength * attackMultiplier );

        bool isCriticalAttack = CriticalPercentChance > 100 || Random.Shared.Next( 1, 101 ) < CriticalPercentChance;

        if ( isCriticalAttack )
        {
            fighterDamage *= 2;
        }

        return fighterDamage;
    }

    public int TakeDamage( int opponentDamage )
    {
        const double ArmorConditionReductionFactor = 0.5;
        const int MinArmorConditionLoss = 5;

        int startHealth = CurrentHealth;
        double armorConditionPercentage = ( double )Armor.ArmorCondition / 100;
        int newHealth = CurrentHealth - ( int )Math.Max( opponentDamage - ArmorPoints * armorConditionPercentage, 0 );

        Armor.ReduceCondition( ( int )Math.Max( opponentDamage * ArmorConditionReductionFactor, MinArmorConditionLoss ) );

        if ( newHealth < 0 )
        {
            newHealth = 0;
        }

        CurrentHealth = newHealth;
        int damageDealt = startHealth - CurrentHealth;

        return damageDealt;
    }

    public void Revive()
    {
        CurrentHealth = MaxHealth;
        Armor.Repair();
    }

    public override string ToString()
    {
        return $"Боец {Name}:\n" +
            $"Класс: {FighterType.Name}\n" +
            $"Раса: {Race.Name}\n" +
            $"Оружие: {Weapon.Name}\n" +
            $"Броня: {Armor.Name}\n" +
            $"Максимальное здоровье: {MaxHealth}\n" +
            $"Текущее здоровье: {CurrentHealth}\n" +
            $"Очки брони: {ArmorPoints}\n" +
            $"Состояние брони: {Armor.ArmorCondition}%\n" +
            $"Сила: {Strength}\n" +
            $"Состояние здоровья: {( IsAlive ? "Жив" : "Мертв" )}";
    }
}
