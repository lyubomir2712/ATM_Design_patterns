namespace Contracts.ActionContracts;

public interface IMoneyFeeService
{
    public decimal Fee(decimal amount);
}