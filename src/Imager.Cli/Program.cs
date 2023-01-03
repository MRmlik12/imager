using Imager.Cli.Commands;
using Spectre.Console;
using Spectre.Console.Cli;

var app = new CommandApp();

app.Configure(config =>
{
    config.AddCommand<ResizeCommand>("resize");

    config.SetExceptionHandler(ex => { AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything); });
});

app.Run(args);