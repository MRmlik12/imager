using System.ComponentModel;
using Spectre.Console.Cli;

namespace Imager.Cli.Options;

public class ConvertOptions : CommandSettings
{
    [Description("Source image file")]
    [CommandOption("-p |--path")]
    public string SourcePath { get; init; } = null!;
    
    [Description("Output path of produced image")]
    [CommandOption("-o|--output")]
    public string OutputPath { get; init; } = null!;
    
    [Description("Quality of converted image")]
    [CommandOption("-q|--quality")]
    public int Quality { get; init; } = 95;
}