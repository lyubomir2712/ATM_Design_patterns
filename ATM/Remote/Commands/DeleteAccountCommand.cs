using Contracts.ActionContracts;
using Contracts.CommandContracts;

namespace Remote;

public class DeleteAccountCommand : ICommand
{
    private readonly IDeleteAccount _deleteAccount;
    private readonly int _accountId;

    public DeleteAccountCommand(IDeleteAccount deleteAccount, int accountId)
    {
        _deleteAccount = deleteAccount;
        _accountId = accountId;
    }

    public void Execute()
    {
        _deleteAccount.Delete(_accountId);
    }
}