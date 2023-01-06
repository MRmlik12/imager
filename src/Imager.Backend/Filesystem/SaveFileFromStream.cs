namespace Imager.Backend.Filesystem;

public static class SaveFileFromStream
{
    public static async Task Save(Stream stream, string outputPath)
    {
        var cancellationToken = new CancellationToken();
        var file = File.Open(outputPath, FileMode.OpenOrCreate);
        
        await stream.CopyToAsync(file, cancellationToken);
        
        file.Close();
        stream.Close();
    }
}