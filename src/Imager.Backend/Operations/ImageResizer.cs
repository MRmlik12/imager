using NetVips;

namespace Imager.Backend.Operations;

public static class ImageResizer
{
    public static void Resize(int width, int height, string imagePath, string outputPath)
    {
        using var image = Image.Thumbnail(imagePath, width, height);
        image.WriteToFile(outputPath);
    }
}