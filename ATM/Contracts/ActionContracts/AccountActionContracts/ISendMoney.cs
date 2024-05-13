namespace Contracts.ActionContracts;

public interface ISendMoney
{
    public void Send(int senderAccountId, int receiverAccountId, decimal amount);
}