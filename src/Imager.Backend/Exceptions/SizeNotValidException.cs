namespace Imager.Backend.Exceptions;

public class SizeNotValidException : BaseImagerException
{
    public SizeNotValidException(string message = "The format of size isn't correct") : base(message)
    {
    }
}