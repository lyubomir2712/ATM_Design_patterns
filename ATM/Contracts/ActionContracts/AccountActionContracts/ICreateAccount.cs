namespace Contracts.ActionContracts;

public interface ICreateAccount
{
    public void Create(string name, decimal balance);
}