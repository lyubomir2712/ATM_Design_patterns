using Contracts;

namespace CashDispenser;

public class Transaction
{
    public int? TransactionId { get; set; }
    public int? SenderUserId { get; set; }
    public Account Sender { get; set; }
    public int? ReceiverUserId { get; set; } 
    public Account Receiver { get; set; } 
    public decimal? Amount { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.UtcNow;
}