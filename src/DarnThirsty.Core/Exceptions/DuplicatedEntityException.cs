namespace DarnThirsty.Core.Exceptions;

public class DuplicatedEntityException : Exception
{
    public DuplicatedEntityException(string property)
        : base($"There's already a record with the property {property} as a value") { }
}