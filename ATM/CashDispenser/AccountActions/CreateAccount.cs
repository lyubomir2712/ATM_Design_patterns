using Contracts.ActionContracts;

namespace CashDispenser.Actions;

public class CreateAccount : ICreateAccount
{
    public void Create(string name, decimal balance)
    {
        //Factory
        decimal balanceVar = balance;

        var context = BankingDbContext.GetInstance();
        
            Account newAccount = new Account
            {
                UserName = name,
                AccountBalance = balance
            };
                
            if (balance <= 500)
            {
                newAccount.Type = AccountType.Standard;
            }
            else if (balance >= 501 && balance <= 1000)
            {
                newAccount.Type = AccountType.Premium;
            }
            else if (balance >= 1001)
            {
                newAccount.Type = AccountType.Platinum;
            }

            context.Accounts.Add((newAccount));
            context.SaveChanges();
            Console.WriteLine($"\nAccount {name} created successfully!");
    } 
}