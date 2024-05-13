using Contracts.ActionContracts;
using Contracts.CommandContracts;

namespace Remote;

public class SendMoneyCommand : ICommand
{

    private readonly ISendMoney _sendMoney;
    private readonly int _senderAccountId;
    private readonly int _receiverAccountId;
    private readonly decimal _amount;
    
    public SendMoneyCommand(ISendMoney sendMoney, int senderAccountId, int receiverAccountId, decimal amount)
    {
        _sendMoney = sendMoney;
        _senderAccountId = senderAccountId;
        _receiverAccountId = receiverAccountId;
        _amount = amount;

    }

    public void Execute()
    {
        _sendMoney.Send(_senderAccountId, _receiverAccountId, _amount);
    }
}