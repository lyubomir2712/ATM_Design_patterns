using Contracts.ActionContracts;
using Contracts.CommandContracts;

namespace Remote;

public class CreateAccountCommand : ICommand
{
    private readonly ICreateAccount _createAccount;
    private readonly string _accountName;
    private readonly decimal _balance;
    public CreateAccountCommand(ICreateAccount createAccount, string accountName, decimal balance)
    {
        _createAccount = createAccount;
        _accountName = accountName;
        _balance = balance;
    }

    public void Execute()
    {
        _createAccount.Create(_accountName, _balance);
    }
}