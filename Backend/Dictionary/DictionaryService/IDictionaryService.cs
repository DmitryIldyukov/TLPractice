namespace Dictionary.DictionaryService;

public interface IDictionaryService
{
    List<string> GetAllTranslations();
    string GetWordTranslation( string word );
    void AddTranslation( string word, string wordTranslation );
    void EditTranslation( string word, string wordTranslation );
    void DeleteTranslation( string word );
    bool IsTranslationExist( string word );
}
