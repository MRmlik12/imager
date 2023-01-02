using CommandLine;
using Imager.Cli.Commands;
using Imager.Cli.Options;

Parser.Default.ParseArguments<ResizeOptions>(args)
    .MapResult(
        options => new ResizeCommand().Handle(options),
        errs => 1
    );