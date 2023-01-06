using Imager.Backend.Exceptions;
using Imager.Backend.Operations;
using Imager.Backend.Validate;
using Imager.Cli.Options;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Imager.Cli.Commands;

internal class ContrastCommand : Command<ContrastOptions>
{
    public override int Execute(CommandContext context, ContrastOptions settings)
    {
        if (!PathValidator.ValidatePath(settings.SourcePath))
            throw new ItemNotExistsException();

        var fileName = Path.GetFileName(settings.SourcePath);

        AnsiConsole.MarkupLine($"Adjusting contrast of {fileName} image...");
        ImageContrast.Setup(settings.SourcePath, settings.OutputPath, settings.ContrastLevel);
        AnsiConsole.MarkupLine("[green]Done[/]  :check_mark_button:");

        return 0;
    }
}