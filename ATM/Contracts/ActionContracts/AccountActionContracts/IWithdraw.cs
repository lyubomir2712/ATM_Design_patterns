namespace Contracts.ActionContracts;

public interface IWithdraw
{
    public void Withdraw(IAccount account, decimal amount, IMoneyFeeService feeService);
}