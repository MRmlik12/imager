using Imager.Cli.Commands;
using Spectre.Console;
using Spectre.Console.Cli;

var app = new CommandApp();

app.Configure(config =>
{
    config.AddCommand<ResizeCommand>("resize");
    config.AddCommand<ConvertCommand>("convert");
    config.AddCommand<ContrastCommand>("contrast");
    config.AddCommand<RotateCommand>("rotate");
    
    config.AddCommand<AboutCommand>("about");

    config.SetExceptionHandler(ex => { AnsiConsole.WriteException(ex, ExceptionFormats.ShortenEverything); });
});

app.Run(args);