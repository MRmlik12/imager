namespace Imager.Backend.Exceptions;

public abstract class BaseImagerException : Exception
{
    protected BaseImagerException(string message) : base(message)
    {
    }
}