using EFCoreMultiDb.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreMultiDb.Data;

public class EFDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Role> Roles { get; set; }

    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        // optionsBuilder.UseSqlServer("Server=127.0.0.1,1433;Database=EFCore;User=sa;Password=root@1234");
        // optionsBuilder.UseMySQL("Server=127.0.0.1;Database=EFCoreMysql;Uid=root;Pwd=123456;");
        optionsBuilder.UseNpgsql("User ID=pg;Password=root@1234;Host=localhost;Port=5432;Database=EFCorePG;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
    }
}