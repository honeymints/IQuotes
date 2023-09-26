using IQuotes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IQuotes.Data;

public class ApplicationDbContext : IdentityDbContext<IdentityUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }
    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        /*modelBuilder.Entity<User>().HasKey(e => e.ID);
        modelBuilder.Entity<IdentityUserLogin<string>>().HasKey(e => e.UserId)*/; /*
        modelBuilder.Entity<User>().HasIndex(e => e.Email).IsUnique(true);*/ //email unique
        modelBuilder.SeedRoles();
    }

    

    public DbSet<User> Users { get; set; }
    public DbSet<Quotes> Quotes { get; set; }
    
   
}