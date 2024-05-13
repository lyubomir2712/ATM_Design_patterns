using Contracts;
using Contracts.ActionContracts;

namespace CashDispenser.Actions.StrategyWithdraw;

public class PremiumWithdraw : IWithdraw
{
    public void Withdraw(IAccount account, decimal amount, IMoneyFeeService feeService)
    {
        
        account.AccountBalance -= amount + feeService.Fee(amount);
        Console.WriteLine($"{amount} were withdrawn from {account.UserName}!");
    }
}