using CashDispenser.Actions;
using Contracts.CommandContracts;
using Contracts.StartUpContracts;
using Remote;

namespace CashDispenser.StartUp;

public class DeleteStartUp : IDeleteStartUp
{
    private IRemote _remote;
    public void DeleteAccount()
    {
        Console.Write("\nEnter account id: ");
        int accountId = Convert.ToInt32(Console.ReadLine());
        
        DeleteAccountCommand deleteAccountCommand =
            new DeleteAccountCommand(new DeleteAccount(), accountId);
        _remote = new Remote.Remote(deleteAccountCommand);
        _remote.ExecuteCommand();
    }
}