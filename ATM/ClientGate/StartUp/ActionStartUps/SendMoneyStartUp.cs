using CashDispenser.Actions;
using Contracts.CommandContracts;
using Contracts.StartUpContracts;
using Remote;

namespace CashDispenser.StartUp;

public class SendMoneyStartUp : ISendMoneyStartUp
{
    private IRemote _remote;

    public void SendMoney()
    {
        Console.Write("\nEnter sender id: ");
        int senderId = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("\nEnter receiver id: ");
        int receiverId = Convert.ToInt32(Console.ReadLine());
        
        Console.Write("\nEnter amount: ");
        decimal amount = Convert.ToDecimal(Console.ReadLine());
        
        SendMoneyCommand sendMoneyCommand =
            new SendMoneyCommand(new SendMoney(), senderId, receiverId, amount);
        _remote = new Remote.Remote(sendMoneyCommand);
        _remote.ExecuteCommand();
    }
}