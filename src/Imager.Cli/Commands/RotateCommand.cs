using Imager.Backend.Exceptions;
using Imager.Backend.Operations;
using Imager.Backend.Validate;
using Imager.Cli.Options;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Imager.Cli.Commands;

public class RotateCommand : Command<RotateOptions>
{
    public override int Execute(CommandContext context, RotateOptions settings)
    {
        if (!PathValidator.ValidatePath(settings.SourcePath))
            throw new ItemNotExistsException();
        
        AnsiConsole.MarkupLine($"Rotating an image...");
        RotateImage.Rotate(settings.SourcePath, settings.OutputPath, settings.Degrees);
        AnsiConsole.MarkupLine("[underline green]Done[/]  :check_mark_button:");

        return 0;
    }
}