using System.Windows.Input;
using Contracts.ActionContracts;

namespace Remote;

public class WithdrawMoneyCommand : Contracts.CommandContracts.ICommand
{
    private readonly IWithdrawMoney _bankingService;
    private readonly int _userId;
    private readonly decimal _amount;
    
    public WithdrawMoneyCommand(IWithdrawMoney bankingService, int userId, decimal amount)
    {
        _bankingService = bankingService;
        _userId = userId;
        _amount = amount;
    }


    public void Execute()
    {
        _bankingService.WithdrawFromAccount(_userId, _amount);
    }
}