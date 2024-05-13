using CashDispenser.Actions.StrategyWithdraw;
using Contracts.ActionContracts;

namespace CashDispenser.Actions;

public class WithdrawMoney : IWithdrawMoney
{
    private IWithdraw _withdraw;

    public WithdrawMoney(IWithdraw withdraw)
    {
        _withdraw = withdraw;
    }
    

    public void WithdrawFromAccount(int accountId, decimal amount)
    {
            var context = BankingDbContext.GetInstance();
            var account = context.Accounts.FirstOrDefault(a => a.UserId == accountId);
            if (account == null)
            {
                Console.WriteLine("\nInvalid account!");
                return;
            }

            _withdraw.Withdraw(account, amount, new MoneyFeeServiceService());
            account.MonthlyWithdrawalCount++;
            context.SaveChanges();
            Console.WriteLine($"\n{amount} withdrawn successfully!");
    }
}