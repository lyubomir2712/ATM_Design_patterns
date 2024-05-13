using System.Net;
using Quartz;

namespace CashDispenser.Actions;

public class MonthlyResetJob : IJob
{
    
    public async Task Execute(IJobExecutionContext context)
    {
        try
        {
            await using (var dbContext = BankingDbContext.GetInstance())
            {
                var accounts = dbContext.Accounts.ToList();
                foreach (var account in accounts)
                {
                    if (account.MonthlyWithdrawalCount <= 10)
                    {
                        account.Type = AccountType.Standard;
                    }
                    else if (account.MonthlyWithdrawalCount >= 11 && account.MonthlyWithdrawalCount <= 20)
                    {
                        account.Type = AccountType.Premium;
                    }
                    else if (account.MonthlyWithdrawalCount > 20)
                    {
                        account.Type = AccountType.Platinum;
                    }

                    account.MonthlyWithdrawalCount = 0;
                }

                await dbContext.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred: {ex.Message}");
        }
    }
}