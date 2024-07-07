using Gladiators.Models.Fighters;
using Gladiators.Services;

namespace Gladiators.GameMaster;

public class GameManager : IGameManager
{
    private readonly IFighterService _fighterService;

    public GameManager( IFighterService fighterService )
    {
        _fighterService = fighterService;
    }

    public void Play()
    {
        Console.WriteLine( "Добро пожаловать в игру 'Gladiators'!" );

        bool isExit = false;
        while ( !isExit )
        {
            ShowMenu();
            string command = Console.ReadLine().ToLower().Trim();
            switch ( command )
            {
                case "add-fighter":
                    CreateFighter();
                    break;
                case "fight":
                    Fight();
                    break;
                case "fighters":
                    ShowFighters();
                    break;
                case "revive-fighters":
                    ReviveFighters();
                    break;
                case "exit":
                    Console.WriteLine( "До свидания!" );
                    isExit = true;
                    break;
                default:
                    Console.WriteLine( $"Команда '{command}' не найдена." );
                    break;
            }
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine( "---------------------------------------" );
        Console.WriteLine( "Доступные команды:" );
        Console.WriteLine( "add-fighter - Добавить бойца на арену" );
        Console.WriteLine( "fight - Начать битву" );
        Console.WriteLine( "fighters - Показать список бойцов" );
        Console.WriteLine( "revive-fighters - Восстановить силы бойцов" );
        Console.WriteLine( "exit - Выйти" );
        Console.Write( "Ввод: " );
    }

    private void CreateFighter()
    {
        IFighter fighter = _fighterService.CreateFighter();
        Console.WriteLine( $"Боец {fighter.Name} успешно создан." );
    }

    private void Fight()
    {
        int round = 0;
        List<IFighter> fighters = _fighterService.GetFighters();
        int fighterCount = fighters.Count;
        if ( fighterCount < 2 )
        {
            ShowFighterCountError( fighterCount );
            return;
        }
        IFighter winner = null;
        Console.WriteLine( "Бой начинается!" );
        while ( fighters.Count( f => f.IsAlive ) > 1 )
        {
            Console.WriteLine( $"Раунд {++round}" );

            fighters = fighters.OrderBy( f => Random.Shared.Next() ).ToList();

            foreach ( IFighter fighter in fighters )
            {
                if ( !fighter.IsAlive )
                {
                    continue;
                }

                IFighter opponent = fighters.Where( f => f != fighter && f.IsAlive ).OrderBy( f => Random.Shared.Next() ).First();
                AttackProcess( fighter, opponent );
            }

            WaitForKeyPress();

            ShowFighters( "Текущее состояние бойцов:" );

            WaitForKeyPress();
        }

        winner = fighters.FirstOrDefault( f => f.IsAlive );

        Console.WriteLine( $"{winner.Name} победил!!!" );
    }

    private void ShowFighters( string message = "Список бойцов:" )
    {
        List<IFighter> fighters = _fighterService.GetFighters();

        if ( fighters.Count == 0 )
        {
            Console.WriteLine( "Список пуст." );
            return;
        }

        Console.WriteLine( message );
        Console.WriteLine();
        foreach ( IFighter fighter in fighters )
        {
            Console.WriteLine( fighter );
            Console.WriteLine();
        }
    }

    private void ReviveFighters()
    {
        _fighterService.ReviveFighters();
        Console.WriteLine( "Бойцы восстановили свои силы." );
    }

    private void AttackProcess( IFighter fighter, IFighter opponent )
    {
        int damage = fighter.CalculateDamage();
        int damageTaken = opponent.TakeDamage( damage );
        Console.WriteLine( $"{fighter.Name} атакует {opponent.Name} и наносит ему {damage} урона." );
        Console.WriteLine( $"{opponent.Name} получает {damageTaken} урона и {( opponent.IsAlive ? "выживает" : "погибает" )}." );
    }

    private void WaitForKeyPress()
    {
        Console.WriteLine( "Нажмите любую клавишу, чтобы продолжить." );
        Console.ReadKey();
    }

    private void ShowFighterCountError( int fighterCount )
    {
        Console.WriteLine( "Невозможно начать битву." );
        Console.WriteLine( $"Минимальное количество бойцов для битвы: 2." );
        Console.WriteLine( $"Текущее количество бойцов: {fighterCount}." );
        Console.WriteLine( $"Добавьте еще {2 - fighterCount} бойца/бойцов." );
    }
}
