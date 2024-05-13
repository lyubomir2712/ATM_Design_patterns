using CashDispenser.Actions;
using Contracts.CommandContracts;
using Contracts.StartUpContracts;
using Remote;

namespace CashDispenser.StartUp;

public class DepositStartUp : IDepositStartUp
{
    private IRemote _remote;
    
    public void Deposit()
    {
        Console.Write("\nEnter account id: ");
        int accountId = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("\nEnter amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        
        DepositMoneyCommand depositMoneyCommand =
            new DepositMoneyCommand(new DepositMoney(), accountId, amount);
        _remote = new Remote.Remote(depositMoneyCommand);
        _remote.ExecuteCommand();
    }
}