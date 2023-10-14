namespace DarnThirsty.Core.Exceptions;

public class ConflictException : Exception
{
    public ConflictException() { }
    public ConflictException(string property)
        : base($"There's already a record with the property {property} as a value") { }
}