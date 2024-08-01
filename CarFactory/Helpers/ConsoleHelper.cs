using CarFactory.Interfaces;

namespace CarFactory.Helpers;

public static class ConsoleHelper
{
    public static T ChooseItemByIndex<T>( List<T> items ) where T : INamedInterface
    {
        int index;
        DisplayOptions( items );
        while ( true )
        {
            string choise = Console.ReadLine();
            if ( int.TryParse( choise, out index ) && index > 0 && index < items.Count() + 1 )
            {
                break;
            }

            Console.Write( "Неверный ввод. Введите допустимое число: " );
        }

        return items[ index - 1 ];
    }

    public static void DisplayOptions<T>( IList<T> items ) where T : INamedInterface
    {
        for ( int i = 0; i < items.Count(); i++ )
        {
            Console.WriteLine( $"{i + 1} - {items[ i ].Name}" );
        }

        Console.Write( "Ввод: " );
    }
}
