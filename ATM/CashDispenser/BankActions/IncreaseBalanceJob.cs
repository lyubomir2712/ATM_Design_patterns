using Quartz;

namespace CashDispenser.BankActions;

public class IncreaseBalanceJob : IJob
{
    public async Task Execute(IJobExecutionContext context)
    {
        await using (var dbContext = BankingDbContext.GetInstance())
        {
            try
            {
                var accounts = dbContext.Accounts.ToList();
                
                foreach (var account in accounts)
                {
                    account.AccountBalance *= 1.001m; 
                }
                
                dbContext.SaveChangesAsync();

                Console.WriteLine("Balance increased for all accounts.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
        
    }
}