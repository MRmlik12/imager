using Imager.Backend.Operations;

namespace Imager.UnitTests.Backend;

public class ConvertImageTests
{
    private const string SourceFileDirectory = "Data/simon-spring.jpg";
    private const string ExpectedFileName = "simon-spring.png";
    private readonly byte[] _pngHeader = { 137, 80, 78, 71 };
    
    [Fact]
    public async Task ConvertJpegToPngFile_VerifyHeader()
    {
        ConvertImage.Convert(SourceFileDirectory, ExpectedFileName, 100);

        await using var fileStream = File.Open(ExpectedFileName, FileMode.Open);
        var buffer = new byte[4];
        var read = await fileStream.ReadAsync(buffer.AsMemory(0, 4));
        
        if (read == 4)
            fileStream.Close();
        
        Assert.True(buffer.SequenceEqual(_pngHeader));
        Assert.True(File.Exists(ExpectedFileName));
    }
}