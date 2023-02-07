using NetVips;

namespace Imager.Backend.Operations;

public static class RotateImage
{
    public static void Rotate(string sourcePath, string outputPath, double degrees)
    {
        using var image = Image.NewFromFile(sourcePath);
        image.Rot180();
        image.Affine(new double[] { 0, -1, 1, 0 });
        image.WriteToFile(outputPath, new VOption
        {
            { "Q", 100 }
        });
    }
}