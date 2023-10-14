namespace DarnThirsty.Core.Exceptions;

public class NotFoundException : Exception
{
    public NotFoundException() { }
    public NotFoundException(string property)
        : base($"No record was found with the property {property}") { }
}