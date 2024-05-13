using Contracts.ActionContracts;

namespace CashDispenser.Actions;

public class DeleteAccount : IDeleteAccount
{
    public void Delete(int accountId)
    {
        var context = BankingDbContext.GetInstance();
        
            var account = context.Accounts.FirstOrDefault(a => a.UserId == accountId);

            if (account != null)
            {
                context.Accounts.Remove(account); 
                context.SaveChanges(); 
                Console.WriteLine($"\nAccount with ID {accountId} has been successfully deleted!");
                return;
            }
            Console.WriteLine($"\nAccount with ID {accountId} not found. Deletion failed.");
    }
}