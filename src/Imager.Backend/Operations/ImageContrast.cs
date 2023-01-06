using NetVips;

namespace Imager.Backend.Operations;

public static class ImageContrast
{
    public static Stream Setup(string sourcePath, float contrast)
    {
        var imageStream = File.Open(sourcePath, FileMode.Open);
        
        var image = Image.VipsloadStream(imageStream);
        image.Colourspace(Enums.Interpretation.Scrgb);
        image = image * contrast - (0.5 * contrast - 0.5);
        image.Colourspace(Enums.Interpretation.Srgb);
        
        image.WriteToStream(imageStream, "", new VOption
        {
            { "Q", 100 }
        });

        return imageStream;
    }
}