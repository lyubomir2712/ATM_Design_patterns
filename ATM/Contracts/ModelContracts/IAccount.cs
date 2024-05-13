namespace Contracts;

public interface IAccount
{
    public int? UserId { get; set; }
    public string? UserName { get; set; }
    public decimal? AccountBalance { get; set; }
    
}