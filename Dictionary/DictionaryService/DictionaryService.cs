using Dictionary.Exceptions;

namespace Dictionary.DictionaryService;

public class DictionaryService : IDictionaryService
{
    private const string _fileName = "dictionary.txt";
    private readonly Dictionary<string, string> _dictionary = new Dictionary<string, string>();

    public DictionaryService()
    {
        LoadDictionaryFromFile();
    }

    private void LoadDictionaryFromFile()
    {
        if ( !File.Exists( _fileName ) )
        {
            File.Create( _fileName ).Close();
        }

        string[] records = File.ReadAllLines( _fileName );
        foreach ( string record in records )
        {
            string[] words = record.Split( "/" );

            if ( words.Length == 2 )
            {
                words[ 0 ] = words[ 0 ].ToLower().Trim();
                words[ 1 ] = words[ 1 ].ToLower().Trim();
                if ( CanAddRecord( words[ 0 ], words[ 1 ] ) )
                {
                    _dictionary.Add( words[ 0 ], words[ 1 ] );
                }
            }
        }
    }

    private bool CanAddRecord( string word, string translation )
    {
        return !_dictionary.Any( record => record.Key == word
            || record.Value == word
            || record.Key == translation
            || record.Value == translation );
    }

    /// <summary>
    /// Указывает, существует ли слово в словаре.
    /// </summary>
    /// <param name="word">Слово</param>
    /// <returns>Возвращает true, если слово существует в словаре, иначе false</returns>
    public bool IsTranslationExist( string word )
    {
        word = word.ToLower().Trim();
        return _dictionary.Any( record => record.Key == word || record.Value == word );
    }

    /// <summary>
    /// Получает все переводы в формате "слово - перевод".
    /// </summary>
    /// <returns>Список строк, каждая из которых представляет собой запись в словаре в формате "слово - перевод".</returns>
    public List<string> GetAllTranslations()
    {
        return _dictionary.Select( record => $"{record.Key} - {record.Value}" ).ToList();
    }

    /// <summary>
    /// Получает перевод слова.
    /// </summary>
    /// <param name="word">Слово, у которого хотим получить перевод.</param>
    /// <returns>Перевод слова.</returns>
    /// <exception cref="RecordNotFoundException">Выбрасывается, если слово или его перевод не найдены в словаре.</exception>
    public string GetWordTranslation( string word )
    {
        word = word.ToLower().Trim();

        if ( _dictionary.TryGetValue( word, out string translation ) )
        {
            return translation;
        }

        string key = _dictionary.FirstOrDefault( rec => rec.Value == word ).Key;
        if ( !string.IsNullOrEmpty( key ) )
        {
            return key;
        }

        throw new RecordNotFoundException( $"Слово или его перевод не найдены." );
    }

    /// <summary>
    /// Добавляет перевод для слова.
    /// </summary>
    /// <param name="word">Слово.</param>
    /// <param name="wordTranslation">Перевод слова.</param>
    /// <exception cref="RecordAlreadyExistException">Выбрасывается, если слово или его перевод уже существуют в словаре.</exception>
    public void AddTranslation( string word, string wordTranslation )
    {
        word = word.ToLower().Trim();
        wordTranslation = wordTranslation.ToLower().Trim();

        if ( !CanAddRecord( word, wordTranslation ) )
        {
            throw new RecordAlreadyExistException( "Слово или его перевод уже существуют в словаре." );
        }

        _dictionary.Add( word, wordTranslation );
        File.AppendAllLines( _fileName, new[] { $"{word}/{wordTranslation}" } );
    }

    /// <summary>
    /// Изменяет перевод слова.
    /// </summary>
    /// <param name="word">Слово.</param>
    /// <param name="wordTranslation">Новый перевод слова.</param>
    /// <exception cref="RecordAlreadyExistException">Выбрасывается, если такой перевод слова уже существует.</exception>
    /// <exception cref="RecordNotFoundException">Выбрасывается, если слово не найдено.</exception>
    public void EditTranslation( string word, string wordTranslation )
    {
        word = word.ToLower().Trim();
        wordTranslation = wordTranslation.ToLower().Trim();

        if ( IsTranslationExist( wordTranslation ) )
        {
            throw new RecordAlreadyExistException( "Такой перевод уже существует." );
        }

        if ( _dictionary.ContainsKey( word ) )
        {
            UpdateTranslationInFile( word, _dictionary[ word ], wordTranslation );
            _dictionary[ word ] = wordTranslation;
            return;
        }

        if ( _dictionary.ContainsValue( word ) )
        {
            DeleteTranslation( word );
            AddTranslation( word, wordTranslation );
            return;
        }

        throw new RecordNotFoundException( $"Слово \'{word}\', к которому вы хотите добавить перевод, не найдено." );
    }

    /// <summary>
    /// Удалить слово и его перевод.
    /// </summary>
    /// <param name="word">Слово, которое хотите удалить вместе с переводом.</param>
    /// <exception cref="RecordNotFoundException">Выбрасывается, если слово не найдено.</exception>
    public void DeleteTranslation( string word )
    {
        word = word.ToLower().Trim();

        if ( _dictionary.ContainsKey( word ) )
        {
            RemoveTranslationFromFile( $"{word}/{_dictionary[ word ]}" );
            _dictionary.Remove( word );
            return;
        }

        string key = _dictionary.FirstOrDefault( record => record.Value == word ).Key;
        if ( !string.IsNullOrEmpty( key ) )
        {
            RemoveTranslationFromFile( $"{key}/{word}" );
            _dictionary.Remove( key );
            return;
        }

        throw new RecordNotFoundException( $"Слово \'{word}\' не найдено." );
    }

    private void RemoveTranslationFromFile( string translation )
    {
        List<string> translations = File.ReadAllLines( _fileName ).ToList();

        int index = translations.FindIndex( record => record == translation );
        if ( index == -1 )
        {
            throw new RecordNotFoundException( $"Запись \'{translation}\' не найдена." );
        }

        translations.RemoveAt( index );

        File.WriteAllLines( _fileName, translations );
    }

    private void UpdateTranslationInFile( string word, string oldTranslation, string newTranslation )
    {
        string oldRecord = $"{word}/{oldTranslation}";
        string newRecord = $"{word}/{newTranslation}";

        List<string> translations = File.ReadAllLines( _fileName ).ToList();
        int index = translations.FindIndex( record => record == oldRecord );
        if ( index == -1 )
        {
            throw new RecordNotFoundException( $"Запись \'{oldRecord}\' не найдена." );
        }

        translations[ index ] = newRecord;

        File.WriteAllLines( _fileName, translations );
    }
}