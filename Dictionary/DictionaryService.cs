using Dictionary.Exceptions;

namespace Dictionary;

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