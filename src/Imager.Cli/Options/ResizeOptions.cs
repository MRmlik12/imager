using CommandLine;

namespace Imager.Cli.Options;

[Verb("crop", HelpText = "Crop the image ")]
public class ResizeOptions
{
    [Option('p', "sourcePath", Required = true, HelpText = "Source image file")]
    public string SourcePath { get; set; } = null!;

    [Option('r', "resolution", Required = true, HelpText = "Resolution of cropped image ex. 1280x720")]
    public string Resolution { get; set; } = null!;

    [Option('o', "outputPath", Required = true, HelpText = "Cropped image output path")]
    public string OutputPath { get; set; } = null!;
}