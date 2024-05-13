using Contracts.ActionContracts;

namespace CashDispenser.Actions.StrategyWithdraw;

public class MoneyFeeServiceService : IMoneyFeeService
{
    public decimal Fee(decimal amount)
    {
        if (amount <= 100)
        {
            return amount * 0.03m;
        }
        else if (amount >= 101 && amount <= 1000)
        {
            return amount * 0.05m;
        }

        return amount * 0.1m;
    }
}