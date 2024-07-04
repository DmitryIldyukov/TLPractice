using Dictionary.Exceptions;

namespace Dictionary;

internal class Program
{
    static readonly DictionaryService dictionaryService = new();

    static void Main( string[] args )
    {
        Console.WriteLine( "######################### СЛОВАРЬ #########################" );

        bool isExit = false;
        while ( !isExit )
        {
            ShowMenu();
            switch ( Console.ReadLine() )
            {
                case "1":
                    GetTranslate();
                    break;
                case "2":
                    AddTranslate();
                    break;
                case "3":
                    GetAllTranslates();
                    break;
                case "9":
                    Quit();
                    isExit = true;
                    break;
                default:
                    Console.WriteLine( "Неверный ввод. Попробуйте снова." );
                    break;
            }
        }
    }

    public static void ShowMenu()
    {
        Console.WriteLine( "----------------------------------------------" );
        Console.WriteLine( "Меню:" );
        Console.WriteLine( "1 - Получить перевод слова." );
        Console.WriteLine( "2 - Добавить свой перевод." );
        Console.WriteLine( "3 - Показать все переводы." );
        Console.WriteLine( "9 - Выход." );
        Console.WriteLine( "----------------------------------------------" );
        Console.Write( "Ввод: " );
    }

    public static void GetTranslate()
    {
        string word = GetNonEmptyStringFromConsole( "Введите слово, у которого хотите получить перевод: " );
        try
        {
            var wordTranslate = dictionaryService.GetWordTranslate( word );
            Console.WriteLine( $"Перевод слова \'{word}\': \'{wordTranslate}\'." );
        }
        catch ( RecordNotFoundException e )
        {
            Console.WriteLine( e.Message );
            Console.Write( $"Хотите ли вы добавить перевод для слова \'{word}\'? Y/N: " );
            if ( Console.ReadLine().ToLower().Trim() == "y" )
            {
                AddTranslate( word );
            }
        }
    }

    public static void AddTranslate( string word = null )
    {
        if ( word == null )
        {
            word = GetNonEmptyStringFromConsole( "Введите слово, которому хотите добавить перевод: " );
        }

        string wordTranslate = GetNonEmptyStringFromConsole( $"Введите перевод для слова \'{word}\': " );

        Console.WriteLine( $"Проверьте верен ли перевод: \'{word}\' - \'{wordTranslate}\'" );
        Console.Write( $"Введите \'Y\' если перевод верен \'N\' если нет: " );

        if ( Console.ReadLine().ToLower().Trim() == "y" )
        {
            try
            {
                dictionaryService.AddTranslation( word, wordTranslate );
                Console.WriteLine( $"Перевод \'{word}\' - \'{wordTranslate}\' успешно добавлен." );
            }
            catch ( RecordAlreadyExistException ex )
            {
                Console.WriteLine( ex.Message );
            }
        }
    }

    public static void GetAllTranslates()
    {
        Console.WriteLine( "Все доступные переводы:" );

        foreach ( var record in dictionaryService.GetAllTranslations() )
        {
            Console.WriteLine( record );
        }
    }

    public static void Quit()
    {
        Console.WriteLine( "Спасибо, что воспользовались приложением! До свидания!" );
    }

    static string GetNonEmptyStringFromConsole( string message, string errorMessage = "Неверный ввод. Введенная строка не может быть пустой. Попробуйте снова." )
    {
        string input;

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
}
