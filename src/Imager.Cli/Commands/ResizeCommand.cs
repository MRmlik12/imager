using Imager.Backend.Scale;
using Imager.Cli.Options;

namespace Imager.Cli.Commands;

public class ResizeCommand : ICommand<ResizeOptions>
{
    public int Handle(ResizeOptions options)
    {
        var (width, height) = options.Resolution.Split("x") switch
        {
            [var w, var h] => (w, h),
            _ => (string.Empty, string.Empty)
        };

        ImageResizer.Resize(int.Parse(width), int.Parse(height), options.SourcePath, options.OutputPath);

        return 0;
    }
}