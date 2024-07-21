namespace Gladiators.Models.Armors;

public interface IArmor
{
    string Name { get; }
    int Armor { get; }
    int ArmorCondition { get; }
    void ReduceCondition( int amount );
    void Repair();
}
