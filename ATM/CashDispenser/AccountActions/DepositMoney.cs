using Contracts.ActionContracts;

namespace CashDispenser.Actions;

public class DepositMoney : IDepositMoney
{
    public void Deposit(int accountId, decimal amount)
    {
            var context = BankingDbContext.GetInstance();
            var account = context.Accounts.FirstOrDefault(a => a.UserId == accountId);

            if (account == null)
            {
                Console.WriteLine("\nInvalid account Id!");
                return;
            }
            
            account.AccountBalance += amount;

            context.SaveChanges();
            Console.WriteLine($"\n{amount} deposited successfully!");
    }
}