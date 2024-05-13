using CashDispenser.Actions;
using CashDispenser.Actions.StrategyWithdraw;
using Contracts.ActionContracts;
using Contracts.StartUpContracts;

namespace CashDispenser.StartUp;

public class AccountTypeLogic : IAccountTypeLogic
{
    private IWithdrawMoney _withdrawMoney;
    
    public IWithdrawMoney CheckAccountType(int accountId, decimal amount)
    {
        var dbContext = BankingDbContext.GetInstance();
        var account = dbContext.Accounts.FirstOrDefault(account => account.UserId == accountId);
        if (account.Type == AccountType.Standard)
        {
             _withdrawMoney = new WithdrawMoney(new StandardWithdraw());
        }
        else if (account.Type == AccountType.Premium)
        {
             _withdrawMoney = new WithdrawMoney(new PremiumWithdraw());
        }
        else if (account.Type == AccountType.Platinum)
        {
             _withdrawMoney = new WithdrawMoney(new PlatinumWithdraw());
        }

        return _withdrawMoney;
    }
}