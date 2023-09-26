using IQuotes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace IQuotes.Data;

public static class ModelBuilderExtensions
{
    public static void SeedRoles(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<IdentityRole>().HasData(new IdentityRole
            {
                Name = "Admin", ConcurrencyStamp = "1", NormalizedName = "ADMIN"
            },
            new IdentityRole
            {
                Name = "User", ConcurrencyStamp = "2", NormalizedName ="USER"
            }
        );

    }
}