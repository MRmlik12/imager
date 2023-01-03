using Imager.Backend.Exceptions;
using Imager.Backend.Scale;
using Imager.Backend.Validate;
using Imager.Cli.Options;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Imager.Cli.Commands;

public class ResizeCommand : Command<ResizeOptions>
{
    public override int Execute(CommandContext context, ResizeOptions settings)
    {
        var (width, height) = settings.Size.Split("x") switch
        {
            [var w, var h] => (w, h),
            _ => (string.Empty, string.Empty)
        };

        if (string.IsNullOrEmpty(width) || string.IsNullOrEmpty(height))
            throw new SizeNotValidException();

        if (!PathValidator.ValidatePath(settings.SourcePath))
            throw new ItemNotExistsException();

        AnsiConsole.MarkupLine("Resizing an image...");
        ImageResizer.Resize(int.Parse(width), int.Parse(height), settings.SourcePath, settings.OutputPath);

        AnsiConsole.MarkupLine("[underline green]Done[/]  :check_mark_button:");

        return 0;
    }
}