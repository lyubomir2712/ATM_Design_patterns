using Microsoft.EntityFrameworkCore;

namespace CashDispenser;

public class DbContextOptionsManager
{

    private DbContextOptionsBuilder _dbContextOptionsBuilder;
    public DbContextOptionsManager(DbContextOptionsBuilder dbContextOptionsBuilder)
    {
        _dbContextOptionsBuilder = dbContextOptionsBuilder;
    }
    public string GetConnectionString()
    {
        Console.Write("Enter the database server: ");
        _dbContextOptionsBuilder.Server(Console.ReadLine());

        Console.Write("Enter the database: ");
        _dbContextOptionsBuilder.Database(Console.ReadLine());
        
        Console.Write("Enter the UserId: ");
        _dbContextOptionsBuilder.UserId(Console.ReadLine());
        
        Console.Write("Enter the Password: ");
        _dbContextOptionsBuilder.Password(Console.ReadLine());

        return _dbContextOptionsBuilder.BuildConnectionString();

    }
}