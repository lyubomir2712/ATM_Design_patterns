using Contracts.CommandContracts;
using Contracts.StartUpContracts;
using Remote;

namespace CashDispenser.StartUp;

public class WithdrawMoneyStartUp : IWithdrawMoneyStartUp
{
    private IRemote _remote;
    
    public void WithdrawMoney()
    {
        
        AccountTypeLogic accountTypeLogic = new AccountTypeLogic();
        
        Console.Write("\nEnter account id: ");
        int accountId = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("\nEnter amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
                
        WithdrawMoneyCommand withdrawMoneyCommand =
            new WithdrawMoneyCommand(accountTypeLogic.CheckAccountType(accountId, amount), accountId, amount);
        _remote = new Remote.Remote(withdrawMoneyCommand);
        _remote.ExecuteCommand();
    }
}