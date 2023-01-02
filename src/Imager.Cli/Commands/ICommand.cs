namespace Imager.Cli.Commands;

public interface ICommand<T> where T : class
{
    int Handle(T options);
}