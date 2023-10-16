
namespace Database.Test;

using IQuotes.Data;
using Microsoft.EntityFrameworkCore;

public class DatabaseFixture : IDisposable
{
    public ApplicationDbContext Context { get; }
    private const string ConnectionUrl = @"Host=localhost;Port=5432;Database=quotes;Username=postgres;Password=gudron; Include Error Detail=true";


    public DatabaseFixture()
    {
        var connectionString = ConnectionUrl;
        var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseNpgsql(connectionString).Options;
        Context = new ApplicationDbContext(options);

    }
    public void Dispose()
    {
        Context.Database.EnsureDeleted();
        Context.Dispose();
    }
}