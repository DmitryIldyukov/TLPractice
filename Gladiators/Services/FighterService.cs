using Gladiators.Models.Armors;
using Gladiators.Models.Fighters;
using Gladiators.Models.Races;
using Gladiators.Models.Type;
using Gladiators.Models.Weapons;

namespace Gladiators.Services;

public class FighterService : IFighterService
{
    private readonly List<IFighter> _fighters = new List<IFighter>();

    public IFighter CreateFighter()
    {
        string name = GetNonEmptyStringFromConsole( "Введите имя бойца: " );
        IFighterType fighterType = ChooseFighterType();
        IRace race = ChooseRace();
        IWeapon weapon = ChooseWeapon();
        IArmor armor = ChooseArmor();
        IFighter fighter = new Fighter( name, fighterType, race, weapon, armor );

        _fighters.Add( fighter );

        return fighter;
    }

    public List<IFighter> GetFighters() => _fighters.ToList();

    private IFighterType ChooseFighterType()
    {
        bool isValidChoise = false;
        IFighterType fighterType = null;
        while ( !isValidChoise )
        {
            isValidChoise = true;
            string message = "Выберите класс бойца:\n" +
                "1 - Рыцарь\n" +
                "2 - Наемний\n" +
                "3 - Кавалерия\n" +
                "Ввод: ";
            switch ( GetNonEmptyStringFromConsole( message ) )
            {
                case "1":
                    fighterType = new Knight();
                    break;
                case "2":
                    fighterType = new Mercenary();
                    break;
                case "3":
                    fighterType = new Cavalry();
                    break;
                default:
                    Console.WriteLine( "Неверный ввод. Попробуйте снова." );
                    isValidChoise = false;
                    break;
            };
        }

        return fighterType;
    }

    private IRace ChooseRace()
    {
        bool isValidChoise = false;
        IRace race = null;
        while ( !isValidChoise )
        {
            isValidChoise = true;
            string message = "Выберите расу бойца:\n" +
                "1 - Человек\n" +
                "2 - Эльф\n" +
                "3 - Дворф\n" +
                "4 - Орк\n" +
                "Ввод: ";
            switch ( GetNonEmptyStringFromConsole( message ) )
            {
                case "1":
                    race = new Human();
                    break;
                case "2":
                    race = new Elf();
                    break;
                case "3":
                    race = new Dwarf();
                    break;
                case "4":
                    race = new Orc();
                    break;
                default:
                    Console.WriteLine( "Неверный ввод. Попробуйте снова." );
                    isValidChoise = false;
                    break;
            };
        }

        return race;
    }

    private IWeapon ChooseWeapon()
    {
        bool isValidChoise = false;
        IWeapon weapon = null;
        while ( !isValidChoise )
        {
            isValidChoise = true;
            string message = "Выберите оружие бойца:\n" +
                "1 - Без оружия\n" +
                "2 - Лук\n" +
                "3 - Молот\n" +
                "4 - Нож\n" +
                "5 - Меч\n" +
                "Ввод: ";
            switch ( GetNonEmptyStringFromConsole( message ) )
            {
                case "1":
                    weapon = new NoWeapon();
                    break;
                case "2":
                    weapon = new Bow();
                    break;
                case "3":
                    weapon = new Hummer();
                    break;
                case "4":
                    weapon = new Knife();
                    break;
                case "5":
                    weapon = new Sword();
                    break;
                default:
                    Console.WriteLine( "Неверный ввод. Попробуйте снова." );
                    isValidChoise = false;
                    break;
            };
        }

        return weapon;
    }

    private IArmor ChooseArmor()
    {
        bool isValidChoise = false;
        IArmor armor = null;
        while ( !isValidChoise )
        {
            isValidChoise = true;
            string message = "Выберите броню бойца:\n" +
                "1 - Без брони\n" +
                "2 - Легкая броня\n" +
                "3 - Средняя броня\n" +
                "4 - Тяжелая броня\n" +
                "Ввод: ";
            switch ( GetNonEmptyStringFromConsole( message ) )
            {
                case "1":
                    armor = new NoArmor();
                    break;
                case "2":
                    armor = new LightArmor();
                    break;
                case "3":
                    armor = new MediumArmor();
                    break;
                case "4":
                    armor = new HeavyArmor();
                    break;
                default:
                    Console.WriteLine( "Неверный ввод. Попробуйте снова." );
                    isValidChoise = false;
                    break;
            };
        }

        return armor;
    }

    private string GetNonEmptyStringFromConsole( string message,
        string errorMessage = "Неверный ввод. Введенная строка не может быть пустой. Попробуйте снова." )
    {
        string input = string.Empty;

        while ( true )
        {
            Console.Write( message );
            input = Console.ReadLine();
            if ( !string.IsNullOrWhiteSpace( input ) )
            {
                break;
            }

            Console.WriteLine( errorMessage );
        }

        return input;
    }

    public void ReviveFighters()
    {
        foreach ( IFighter fighter in _fighters )
        {
            fighter.Revive();
        }
    }
}