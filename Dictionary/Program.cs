namespace Dictionary;

internal class Program
{
    static readonly DictionaryService DictionaryService = new DictionaryService();

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

    static string GetNonEmptyStringFromConsole( string message, string errorMessage = "Неверный ввод. Введенная строка не может быть пустой. Попробуйте снова." )
    {
        string input;
        do
        {
            Console.Write( message );
            input = Console.ReadLine();

            if ( string.IsNullOrWhiteSpace( input ) )
                Console.WriteLine( errorMessage );

        } while ( string.IsNullOrWhiteSpace( input ) );

        return input;
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
            var wordTranslate = DictionaryService.GetWordTranslate( word );
            Console.WriteLine( $"Перевод слова \'{word}\': \'{wordTranslate}\'." );
        }
        catch ( RecordNotFoundException e )
        {
            Console.WriteLine( e.Message );
            Console.Write( $"Хотите ли вы добавить перевод для слова \'{word}\'? Y/N: " );
            if ( Console.ReadLine().ToLower().Trim() == "y" )
                AddTranslate( word );
        }
    }

    public static void GetAllTranslates()
    {
        Console.WriteLine( "Все доступные переводы:" );

        foreach ( var record in DictionaryService.GetAllTranslations() )
            Console.WriteLine( record );
    }

    public static void AddTranslate( string? word = null )
    {
        if ( word == null )
            word = GetNonEmptyStringFromConsole( "Введите слово, которому хотите добавить перевод: " );

        string wordTranslate = GetNonEmptyStringFromConsole( $"Введите перевод для слова \'{word}\': " );

        Console.WriteLine( $"Проверьте верен ли перевод: \'{word}\' - \'{wordTranslate}\'" );
        Console.Write( $"Введите \'Y\' если перевод верен \'N\' если нет: " );

        if ( Console.ReadLine().ToLower().Trim() == "y" )
        {
            try
            {
                DictionaryService.AddTranslation( word, wordTranslate );
                Console.WriteLine( $"Перевод \'{word}\' - \'{wordTranslate}\' успешно добавлен." );
            }
            catch ( RecordAlreadyExistException ex )
            {
                Console.WriteLine( ex.Message );
            }
        }
    }

    public static void Quit()
    {
        Console.WriteLine( "Спасибо, что воспользовались приложением! До свидания!" );
    }
}

public class DictionaryService
{
    private const string _fileName = "dictionary.txt";
    private readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>();

    public DictionaryService()
    {
        GetWordsFromFile();
    }

    private void GetWordsFromFile()
    {
        if ( !File.Exists( _fileName ) )
            File.Create( _fileName ).Close();

        string[] records = File.ReadAllLines( _fileName );
        foreach ( string record in records )
        {
            string[] words = record.Split( "/" );

            if ( words.Length == 2 )
            {
                words[ 0 ] = words[ 0 ].ToLower().Trim();
                words[ 1 ] = words[ 1 ].ToLower().Trim();
                if ( RecordCanBeAdded( words[ 0 ], words[ 1 ] ) )
                    _dictionary.Add( words[ 0 ], words[ 1 ] );
            }
        }
    }

    private bool RecordCanBeAdded( string word, string translate ) =>
        !_dictionary.Any( record => record.Key == word || record.Value == word || record.Key == translate || record.Value == translate );

    /// <summary>
    /// Получает все переводы в формате "слово - перевод".
    /// </summary>
    /// <returns>Список строк, каждая из которых представляет собой запись в словаре в формате "слово - перевод".</returns>
    public List<string> GetAllTranslations() =>
        _dictionary.Select( record => $"{record.Key} - {record.Value}" ).ToList();

    /// <summary>
    /// Получает перевод слова.
    /// </summary>
    /// <param name="word">Слово, у которого хотим получить перевод.</param>
    /// <returns>Перевод слова.</returns>
    /// <exception cref="RecordNotFoundException">Выбрасывается, если слово или его перевод не найдены в словаре.</exception>
    public string GetWordTranslate( string word )
    {
        word = word.ToLower().Trim();

        if ( _dictionary.TryGetValue( word, out var translate ) )
            return translate;

        var key = _dictionary.FirstOrDefault( rec => rec.Value == word ).Key;
        if ( key != null )
            return key;

        throw new RecordNotFoundException( $"Слово или его перевод не найдены." );
    }

    /// <summary>
    /// Добавляет перевод для слова.
    /// </summary>
    /// <param name="word">Слово.</param>
    /// <param name="wordTranslate">Перевод слова.</param>
    /// <exception cref="RecordAlreadyExistException">Выбрасывается, если слово или его перевод уже существуют в словаре.</exception>
    public void AddTranslation( string word, string wordTranslate )
    {
        word = word.ToLower().Trim();
        wordTranslate = wordTranslate.ToLower().Trim();

        if ( !RecordCanBeAdded( word, wordTranslate ) )
            throw new RecordAlreadyExistException( "Слово или его перевод уже существуют в словаре." );

        _dictionary.Add( word, wordTranslate );
        File.AppendAllLines( _fileName, new[] { $"{word}/{wordTranslate}" } );
    }
}

public class RecordNotFoundException : Exception
{
    public RecordNotFoundException( string message ) : base( message ) { }
}

public class RecordAlreadyExistException : Exception
{
    public RecordAlreadyExistException( string message ) : base( message ) { }
}
