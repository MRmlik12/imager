namespace Imager.Backend.Validate;

public static class PathValidator
{
    public static bool ValidatePath(string path)
    {
        return File.Exists(path);
    }
}