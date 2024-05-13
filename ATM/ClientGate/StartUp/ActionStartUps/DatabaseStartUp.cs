using Contracts.StartUpContracts;
using Microsoft.EntityFrameworkCore;

namespace CashDispenser.StartUp;

public class DatabaseStartUp : IDatabaseStartUp
{
    public void  ChooseBank()
    {
        BankingDbContext bankingDbContext = BankingDbContext.GetInstance();
        bankingDbContext.Database.OpenConnection();
    }
}