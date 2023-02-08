using NetVips;

namespace Imager.Backend.Operations;

public static class RotateImage
{
    public static void Rotate(string sourcePath, string outputPath, double degrees)
    {
        using var image = Image.NewFromFile(sourcePath);
        using var rotatedImage = image.Rotate(degrees);
        
        rotatedImage.WriteToFile(outputPath, new VOption
        {
            { "Q", 100 }
        });
    }
}