namespace Imager.Backend.Exceptions;

public class ItemNotExistsException : BaseImagerException
{
    public ItemNotExistsException(string message = "Item not found in source directory") : base(message)
    {
    }
}