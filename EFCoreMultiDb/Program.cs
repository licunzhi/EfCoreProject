using EFCoreMultiDb.Data;
using EFCoreMultiDb.Entities;

using var efDbContext = new EFDbContext();

// Create a new one 
var user = new User()
{
    FirstName = "Sakura",
    LastName = "Rain",
    PhoneNumber = "12345678901"
};
var role = new Role()
{
    RoleName = "Admin",
};
user.Roles = new List<Role>() { role };
efDbContext.Add(user);
await efDbContext.SaveChangesAsync();