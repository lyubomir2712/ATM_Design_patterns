using CashDispenser.Actions;
using CashDispenser.StartUp;
using Contracts.StartUpContracts;
using Remote;


namespace CashDispenser.Facade;

public class StartUpFacade
{
    public StartUpFacade()
    {
        DatabaseStartUp = new DatabaseStartUp();
        CreateAccountStartUp = new CreateAccountStartUp();
        CheckBalanceStartUp = new CheckBalanceStartUp();
        DeleteStartUp = new DeleteStartUp();
        DepositStartUp = new DepositStartUp();
        SendMoneyStartUp = new SendMoneyStartUp();
        WithdrawMoneyStartUp = new WithdrawMoneyStartUp();
    }

    public readonly DatabaseStartUp DatabaseStartUp;
    public readonly CreateAccountStartUp CreateAccountStartUp;
    public readonly CheckBalanceStartUp CheckBalanceStartUp;
    public readonly DeleteStartUp DeleteStartUp;
    public readonly DepositStartUp DepositStartUp;
    public readonly SendMoneyStartUp SendMoneyStartUp;
    public readonly WithdrawMoneyStartUp WithdrawMoneyStartUp;
}