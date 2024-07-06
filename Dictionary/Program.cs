using Dictionary.DictionaryService;
using Dictionary.Exceptions;

namespace Dictionary;

internal class Program
{
    static readonly IDictionaryService dictionaryService = new DictionaryService.DictionaryService();

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
                    Translate();
                    break;
                case "2":
                    AddTranslation();
                    break;
                case "3":
                    ShowAllTranslations();
                    break;
                case "4":
                    EditTranslation();
                    break;
                case "5":
                    DeleteTranslation();
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
        Console.WriteLine( "4 - Изменить перевод слова." );
        Console.WriteLine( "5 - Удалить перевод." );
        Console.WriteLine( "9 - Выход." );
        Console.WriteLine( "----------------------------------------------" );
        Console.Write( "Ввод: " );
    }

    public static void Translate()
    {
        string word = GetNonEmptyStringFromConsole( "Введите слово, у которого хотите получить перевод: " );
        try
        {
            string wordTranslation = dictionaryService.GetWordTranslation( word );
            Console.WriteLine( $"Перевод слова \'{word}\': \'{wordTranslation}\'." );
        }
        catch ( RecordNotFoundException e )
        {
            Console.WriteLine( e.Message );
            Console.Write( $"Хотите ли вы добавить перевод для слова \'{word}\'? Y/N: " );
            if ( IsConfirmedFromConsole() )
            {
                AddTranslation( word );
            }
        }
    }

    public static void AddTranslation( string word = null )
    {
        if ( string.IsNullOrEmpty( word ) )
        {
            word = GetNonEmptyStringFromConsole( "Введите слово, которому хотите добавить перевод: " );
        }

        if ( dictionaryService.IsTranslationExist( word ) )
        {
            Console.Write( $"Перевод у слова \'{word}\' уже существует, хотите ли вы изменить его перевод? Y/N: " );
            if ( IsConfirmedFromConsole() )
            {
                EditTranslation( word );
            }

            return;
        }

        string wordTranslation = GetNonEmptyStringFromConsole( $"Введите перевод для слова \'{word}\': " );

        Console.WriteLine( $"Проверьте верен ли перевод: \'{word}\' - \'{wordTranslation}\'" );
        Console.Write( $"Введите \'Y\' если перевод верен \'N\' если нет: " );

        if ( IsConfirmedFromConsole() )
        {
            try
            {
                dictionaryService.AddTranslation( word, wordTranslation );
                Console.WriteLine( $"Перевод \'{word}\' - \'{wordTranslation}\' успешно добавлен." );
            }
            catch ( RecordAlreadyExistException ex )
            {
                Console.WriteLine( ex.Message );
            }
        }
    }

    public static void ShowAllTranslations()
    {
        Console.WriteLine( "Все доступные переводы:" );

        foreach ( string record in dictionaryService.GetAllTranslations() )
        {
            Console.WriteLine( record );
        }
    }

    public static void EditTranslation( string word = null )
    {
        if ( string.IsNullOrEmpty( word ) )
        {
            word = GetNonEmptyStringFromConsole( "Введите слово, у которого хотите изменить перевод: " );
        }

        string wordTranslation = GetNonEmptyStringFromConsole( $"Введите перевод слова \'{word}\': " );

        Console.WriteLine( $"Вы точно хотите изменить перевод слова \'{word}\' на \'{wordTranslation}\'? Y/N: " );
        if ( IsConfirmedFromConsole() )
        {
            try
            {
                dictionaryService.EditTranslation( word, wordTranslation );
                Console.WriteLine( $"Перевод успешно изменен." );
            }
            catch ( RecordAlreadyExistException e )
            {
                Console.WriteLine( e.Message );
            }
            catch ( RecordNotFoundException e )
            {
                Console.WriteLine( e.Message );
            }
        }
    }

    public static void DeleteTranslation()
    {
        string word = GetNonEmptyStringFromConsole( $"Введите слово, которое хотите удалить вместе с его переводом: " );
        Console.WriteLine( $"Вы точно хотите удалить слово \'{word}\' и его перевод? Y/N: " );

        if ( IsConfirmedFromConsole() )
        {
            try
            {
                dictionaryService.DeleteTranslation( word );
                Console.WriteLine( "Перевод успешно удален." );
            }
            catch ( RecordNotFoundException e )
            {
                Console.WriteLine( e.Message );
            }
        }

    }

    public static void Quit()
    {
        Console.WriteLine( "Спасибо, что воспользовались приложением! До свидания!" );
    }

    public static string GetNonEmptyStringFromConsole( string message, string errorMessage = "Неверный ввод. Введенная строка не может быть пустой. Попробуйте снова." )
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

    public static bool IsConfirmedFromConsole( string confirmWord = "y", string cancelWord = "n" )
    {
        string answer = string.Empty;
        confirmWord = confirmWord.ToLower();
        cancelWord = cancelWord.ToLower();

        while ( true )
        {
            answer = Console.ReadLine().ToLower().Trim();
            if ( !string.IsNullOrEmpty( answer ) && ( answer == confirmWord || answer == cancelWord ) )
            {
                break;
            }

            Console.Write( $"Неверный ввод. Введите \'{confirmWord}\' чтобы подтвердить действие, иначе \'{cancelWord}\': " );
        }

        return answer == confirmWord;
    }
}
