using Contracts;
using Contracts.ActionContracts;

namespace CashDispenser.Actions.StrategyWithdraw;

public class StandardWithdraw : IWithdraw
{
    
    
    public void Withdraw(IAccount account, decimal amount, IMoneyFeeService feeService)
    {
        if (account.AccountBalance >= amount)
        {
            account.AccountBalance -= amount + feeService.Fee(amount);
            Console.WriteLine($"{amount} were withdrawn from {account.UserName}!");
        }
        else
        {
            Console.WriteLine("Insufficient balance!");
        }
    }
}