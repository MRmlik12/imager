using Imager.Backend.Exceptions;
using Imager.Backend.Operations;
using Imager.Backend.Validate;
using Imager.Cli.Options;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Imager.Cli.Commands;

public class ConvertCommand : Command<ConvertOptions>
{
    public override int Execute(CommandContext context, ConvertOptions settings)
    {
        if (!PathValidator.ValidatePath(settings.SourcePath))
            throw new ItemNotExistsException();

        var extension = Path.GetExtension(settings.OutputPath);
        
        AnsiConsole.MarkupLine($"Converting an image to {extension}...");
        ConvertImage.Convert(settings.SourcePath, settings.OutputPath, settings.Quality);
        AnsiConsole.MarkupLine("[underline green]Done[/]  :check_mark_button:");

        return 0;
    }
}