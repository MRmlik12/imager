using System.ComponentModel;
using Spectre.Console.Cli;

namespace Imager.Cli.Options;

internal class ContrastOptions : CommandSettings
{
    [Description("Source image file")]
    [CommandOption("-p|--path")]
    public string SourcePath { get; init; } = null!;

    [Description("Output path of produced image")]
    [CommandOption("-o|--output")]
    public string OutputPath { get; init; } = null!;

    [Description("Contrast as floating point number e.g 0.5, 0.7")]
    [CommandOption("-c|--contrast")]
    public double ContrastLevel { get; init; } = 1.5;
}