using Contracts.CommandContracts;

namespace Remote;

public class Remote : IRemote
{
    private readonly ICommand _command;

    public Remote(ICommand command)
    {
        _command = command;
    }

    public void ExecuteCommand()
    {
        _command.Execute();
    }
}