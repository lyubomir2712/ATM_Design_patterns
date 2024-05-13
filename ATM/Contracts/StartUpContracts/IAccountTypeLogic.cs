using Contracts.ActionContracts;

namespace Contracts.StartUpContracts;

public interface IAccountTypeLogic
{
    public IWithdrawMoney CheckAccountType(int accountId, decimal amount);
}