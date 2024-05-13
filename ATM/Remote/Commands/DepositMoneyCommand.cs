using Contracts.ActionContracts;
using Contracts.CommandContracts;


namespace Remote;

public class DepositMoneyCommand : ICommand
{
    private readonly IDepositMoney _depositMoney;
    private readonly int _userId;
    private readonly decimal _amount;

    public DepositMoneyCommand(IDepositMoney depositMoney, int userId, decimal amount)
    {
        _depositMoney = depositMoney;
        _userId = userId;
        _amount = amount;
    }

    public void Execute()
    {
        _depositMoney.Deposit(_userId, _amount);
    }
}