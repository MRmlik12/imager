using Spectre.Console;
using Spectre.Console.Cli;

namespace Imager.Cli.Commands;

public class AboutCommand : Command
{
    public override int Execute(CommandContext context)
    {
        var imagerVersion = typeof(AboutCommand).Assembly.GetName().Version;

        AnsiConsole.MarkupLine("[yellow]Author: [link=https://github.com/MRmlik12]Daniel Olczyk (MRmlik12)[/][/]");
        AnsiConsole.MarkupLine("[aqua]Repository: [link]https://github.com/MRmlik12/imager[/][/]");
        AnsiConsole.MarkupLine($"[purple].NET Version: {Environment.Version}[/]");
        AnsiConsole.MarkupLine($"[blue]imager version: {imagerVersion}[/]");

        return 0;
    }
}