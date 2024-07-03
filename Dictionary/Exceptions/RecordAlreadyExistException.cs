namespace Dictionary.Exceptions;

public class RecordAlreadyExistException : Exception
{
    public RecordAlreadyExistException( string message ) : base( message ) { }
}
