using Imager.Cli.Options;
using Spectre.Console.Cli;

namespace Imager.Cli.Commands;

internal class ContrastCommand : Command<ContrastOptions>
{
    public override int Execute(CommandContext context, ContrastOptions settings)
    {
        return 0;
    }
}