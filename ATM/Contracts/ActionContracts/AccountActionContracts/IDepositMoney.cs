namespace Contracts.ActionContracts;

public interface IDepositMoney
{
    public void Deposit(int accountId, decimal amount);
}