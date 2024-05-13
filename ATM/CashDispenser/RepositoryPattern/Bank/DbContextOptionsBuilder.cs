using Microsoft.Data.SqlClient;

namespace CashDispenser;

public class DbContextOptionsBuilder
{
    private string _server;
    private string _database;
    private string _userId;
    private string _password;
    // private readonly bool _multipleActiveResultSets = true;
    // private readonly bool _trustServerCertificate = true;
    
    

    public DbContextOptionsBuilder Server(string server)
    {
        _server = server;
        return this;
    }

    public DbContextOptionsBuilder Database(string database)
    {
        _database = database;
        return this;
    }

    public DbContextOptionsBuilder UserId(string userId)
    {
        _userId = userId;
        return this;
    }

    public DbContextOptionsBuilder Password(string password)
    {
        _password = password;
        return this;
    }
    public string BuildConnectionString()
    {
        var connectionString =
            $"Server={_server};Database={_database};User Id={_userId};Password={_password};MultipleActiveResultSets=true;TrustServerCertificate=true;";
        // new SqlConnectionStringBuilder
        // {
        //     DataSource = _server,
        //     InitialCatalog = _database,
        //     UserID = _userId,
        //     Password = _password,
        //     MultipleActiveResultSets = _multipleActiveResultSets,
        //     TrustServerCertificate = _trustServerCertificate
        // };

        return connectionString;
    }
}