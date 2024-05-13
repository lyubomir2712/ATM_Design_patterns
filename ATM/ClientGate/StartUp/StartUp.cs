using CashDispenser.Actions;
using CashDispenser.Actions.StrategyWithdraw;
using CashDispenser.Facade;
using Contracts.CommandContracts;
using Contracts.StartUpContracts;
using Remote;

namespace CashDispenser.StartUp;

public class StartUp : IStartUp
{
    private readonly StartUpFacade _startUpFacade = new StartUpFacade();
    public void Start()
    {
        _startUpFacade.DatabaseStartUp.ChooseBank();
        
        Console.WriteLine("\n" +
            "Create: creating account\n" +
            "Delete: deleting account\n" +
            "Check: checking account balance\n" +
            "Deposit: deposit money to an account\n" +
            "Withdraw: withdraw money from an account\n" +
            "Send: send money from one account to another" +
            "\n");
        
        string input = String.Empty;
        while(input != "Exit")
        {
            
            Console.Write("\nEnter command: ");
            input = Console.ReadLine();
            
            if (input == "Create")
                _startUpFacade.CreateAccountStartUp.CreateAccount(); 
            
            else if (input == "Delete")
                _startUpFacade.DeleteStartUp.DeleteAccount();
            
            else if (input == "Check")
                _startUpFacade.CheckBalanceStartUp.CheckBalance();
            
            else if (input == "Deposit")
                _startUpFacade.DepositStartUp.Deposit();
            
            else if (input == "Send")
                _startUpFacade.SendMoneyStartUp.SendMoney();
            
            else if (input == "Withdraw")
                _startUpFacade.WithdrawMoneyStartUp.WithdrawMoney();
        }
    }
}