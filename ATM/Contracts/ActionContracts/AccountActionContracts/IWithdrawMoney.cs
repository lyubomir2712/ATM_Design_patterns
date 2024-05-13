namespace Contracts.ActionContracts;

public interface IWithdrawMoney
{
    public void WithdrawFromAccount(int accountId, decimal amount);
}