namespace DarnThirsty.Core.Exceptions;

public class NoContentException : Exception
{
    public NoContentException() { }
    public NoContentException(string message) : base(message) { }
}