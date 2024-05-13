using System.ComponentModel.DataAnnotations;
using Microsoft.Identity.Client;
using Contracts;

namespace CashDispenser;

public class Account : Contracts.IAccount
{
    [Key]
    public int? UserId { get; set; }
    public string? UserName { get; set; }
    public decimal? AccountBalance { get; set; }
    
    public int MonthlyWithdrawalCount { get; set; }
    public AccountType Type { get; set; }
}