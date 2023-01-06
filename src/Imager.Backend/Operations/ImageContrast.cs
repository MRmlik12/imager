using NetVips;

namespace Imager.Backend.Operations;

public static class ImageContrast
{
    public static void Setup(string sourcePath, string outputPath, double contrast)
    {
        var image = Image.NewFromFile(sourcePath);

        image.Colourspace(Enums.Interpretation.Scrgb);
        image = image * contrast - (0.5 * contrast - 0.5);
        image.Colourspace(Enums.Interpretation.Srgb);

        image.WriteToFile(outputPath, new VOption
        {
            { "Q", 100 }
        });
    }
}