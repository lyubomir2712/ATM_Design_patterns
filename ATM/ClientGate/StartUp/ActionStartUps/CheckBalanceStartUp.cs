using CashDispenser.Actions;
using Contracts.ActionContracts;
using Contracts.CommandContracts;
using Contracts.StartUpContracts;
using Remote;

namespace CashDispenser.StartUp;

public class CheckBalanceStartUp : ICheckBalanceStartUp
{
    private IRemote _remote;
    
    public void CheckBalance()
    {
        Console.Write("\nEnter account id: ");
        int accountId = Convert.ToInt32(Console.ReadLine());
        
        CheckBalanceCommand deleteAccountCommand =
            new CheckBalanceCommand(new CheckBalance(), accountId);
        _remote = new Remote.Remote(deleteAccountCommand);
        _remote.ExecuteCommand();
    }
}