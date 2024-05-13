using Contracts.ActionContracts;

namespace CashDispenser.Actions;

public class SendMoney : ISendMoney
{
    public void Send(int senderAccountId, int receiverAccountId, decimal amount)
    {
            var context = BankingDbContext.GetInstance();
            var senderAccount = context.Accounts.FirstOrDefault(a => a.UserId == senderAccountId);
            var receiverAccount = context.Accounts.FirstOrDefault(a => a.UserId == receiverAccountId);

            if (senderAccount == null)
            {
                Console.WriteLine("\nInvalid sender account id!");
                return;
            }

            if (receiverAccount == null)
            {
                Console.WriteLine("\nInvalid receiver account id!");
                return;
            }

            if (senderAccount.AccountBalance < amount)
            {
                Console.WriteLine("\nInsufficient funds!");
                return;
            }

            senderAccount.AccountBalance -= amount;
            receiverAccount.AccountBalance += amount;

            context.SaveChanges();

            Console.WriteLine($"\n{amount} sent successfully!");
    }
}