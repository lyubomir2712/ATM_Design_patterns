using Microsoft.EntityFrameworkCore;

namespace CashDispenser;

public class BankingDbContext : DbContext
{
    
    private static BankingDbContext _instance;
    private readonly DbContextOptionsManager _dbContextOptionsManager;
    private string connectionString;
    private BankingDbContext(DbContextOptions<BankingDbContext> options, DbContextOptionsManager dbContextOptionsManager) : base(options)
    {
        _dbContextOptionsManager = dbContextOptionsManager;
    }
    
    public BankingDbContext()
    {
    }
    
    public static BankingDbContext GetInstance()
    {
        if (_instance == null)
        {
            
            var optionsBuilder = new DbContextOptionsBuilder<BankingDbContext>();
            _instance = new BankingDbContext(optionsBuilder.Options, new DbContextOptionsManager(new DbContextOptionsBuilder()));
        }
    
        return _instance;
    }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Transaction> Transactions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Sender)
            .WithMany()
            .HasForeignKey(t => t.SenderUserId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Transaction>()
            .HasOne(t => t.Receiver)
            .WithMany()
            .HasForeignKey(t => t.ReceiverUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }

    protected override void OnConfiguring(Microsoft.EntityFrameworkCore.DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=localhost;Database=ATM;User Id=SA;Password=Password123;MultipleActiveResultSets=true;TrustServerCertificate=true;");
        if (connectionString == null)
        {
            connectionString = _instance._dbContextOptionsManager.GetConnectionString();
        }
        optionsBuilder.UseSqlServer(connectionString);
    }
}