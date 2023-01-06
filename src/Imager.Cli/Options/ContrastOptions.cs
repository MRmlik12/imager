using System.ComponentModel;
using Spectre.Console.Cli;

namespace Imager.Cli.Options;

internal class ContrastOptions : CommandSettings
{
    [Description("Source image file")]
    [CommandOption("-p |--path")]
    public string SourcePath { get; init; } = null!;
    
    [Description("Output path of produced image")]
    [CommandOption("-o|--output")]
    public string OutputPath { get; init; } = null!;

    [Description("Contrast in %")]
    [CommandOption("-c|--contrast")]
    public int ContrastLevel { get; init; } = 50;
}