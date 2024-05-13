using CashDispenser.Actions;
using Contracts.CommandContracts;
using Remote;

namespace CashDispenser.StartUp;

public class CreateAccountStartUp
{
    private IRemote _remote;
    
    public void CreateAccount()
    {
        Console.Write("\nEnter account name: ");
        string? accountName = Console.ReadLine();
        
        Console.Write("\nEnter account balance: ");
        decimal balance = Convert.ToDecimal(Console.ReadLine()); 
        
        CreateAccountCommand createAccountCommand = new CreateAccountCommand(new CreateAccount(), accountName, balance);
        _remote = new Remote.Remote(createAccountCommand);
        _remote.ExecuteCommand();
    }
}