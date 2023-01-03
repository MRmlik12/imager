using System.ComponentModel;
using Spectre.Console.Cli;

namespace Imager.Cli.Options;

public class ResizeOptions : CommandSettings
{
    [Description("Source image file")]
    [CommandOption("-p |--path")]
    public string SourcePath { get; init; } = null!;

    [Description("Size of cropped image ex. 1280x720")]
    [CommandOption("-s|--size")]
    public string Size { get; init; } = null!;

    [Description("Output path of produced image")]
    [CommandOption("-o|--output")]
    public string OutputPath { get; init; } = null!;
}