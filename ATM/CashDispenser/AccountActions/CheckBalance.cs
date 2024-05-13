using Contracts.ActionContracts;

namespace CashDispenser.Actions;

public class CheckBalance : ICheckBalance
{
    public void Check(int accountId)
    {
            var context = BankingDbContext.GetInstance();
            var account = context.Accounts.FirstOrDefault(a => a.UserId == accountId);

            if (account != null)
            {
                Console.WriteLine($"Account Balance for Account {account.UserName}: {account.AccountBalance}");
            }
            else
            {
                Console.WriteLine($"Account with ID {accountId} not found.");
            }
    }
}