using EFCoreDemo.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreDemo.Data;

public class EFDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=EFCoreDemo;User=sa;Password=root@1234");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}