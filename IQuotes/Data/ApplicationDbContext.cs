using IQuotes.Models;
using Microsoft.EntityFrameworkCore;

namespace IQuotes.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //modelBuilder.Entity<User>().HasMany(e => e.Quotes);
        modelBuilder.Entity<User>().HasKey(e => e.ID);
        modelBuilder.Entity<User>().HasIndex(e => e.Email).IsUnique(true); //email unique
    }

    
    public DbSet<User> Users { get; set; }
    public DbSet<Quotes> Quotes { get; set; }
    
   
}