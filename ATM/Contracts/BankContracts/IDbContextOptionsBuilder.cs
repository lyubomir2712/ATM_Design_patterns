using Microsoft.EntityFrameworkCore;

namespace Contracts.BankContracts;

public interface IDbContextOptionsBuilder
{
    public string BuildConnectionString();
}