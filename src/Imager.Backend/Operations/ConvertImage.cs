using NetVips;

namespace Imager.Backend.Operations;

public static class ConvertImage
{
    public static void Convert(string sourcePath, string outputPath, int quality)
    {
        using var image = Image.NewFromFile(sourcePath);
        image.WriteToFile(outputPath, new VOption
        {
            { "Q", quality }
        });
    }
}