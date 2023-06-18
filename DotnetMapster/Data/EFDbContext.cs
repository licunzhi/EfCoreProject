using DotnetMapster.Model;
using Microsoft.EntityFrameworkCore;

namespace DotnetMapster.Data;

public class EFDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=DotnetMapster;User=sa;Password=root@1234");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}