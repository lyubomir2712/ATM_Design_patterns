using Contracts;
using Contracts.ActionContracts;

namespace CashDispenser.Actions.StrategyWithdraw;

public class PlatinumWithdraw : IWithdraw
{
    public void Withdraw(IAccount account, decimal amount, IMoneyFeeService feeService)
    {
        decimal cashback = amount * 0.1m;
        account.AccountBalance -= amount - cashback + feeService.Fee(amount);
        Console.WriteLine("Insufficient balance!");
    }

    
}