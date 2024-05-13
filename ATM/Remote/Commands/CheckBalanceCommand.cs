using Contracts.ActionContracts;
using Contracts.CommandContracts;

namespace Remote;

public class CheckBalanceCommand : ICommand
{
    private readonly ICheckBalance _checkBalance;
    private readonly int _accountId;
    
    public CheckBalanceCommand(ICheckBalance checkBalance, int accountId)
    {
        _checkBalance = checkBalance;
        _accountId = accountId;
    }
    public void Execute()
    {
        _checkBalance.Check(_accountId);
    }
}