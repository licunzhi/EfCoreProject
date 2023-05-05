// See https://aka.ms/new-console-template for more information

using EfCoreProject.Data;
using EfCoreProject.Entities;

using var efDbContext = new EFDbContext();

// Create a new one 
// var user = new User()
// {
//     FirstName = "Sakura",
//     LastName = "Rain",
//     PhoneNumber = "12345678901"
// };
// var role = new Role()
// {
//     RoleName = "Admin",
// };
// user.Roles = new List<Role>() { role };
// efDbContext.Add(user);
//
// efDbContext.SaveChanges();

// query the result
// var user = efDbContext.Users.FirstOrDefault();
// Console.WriteLine($"Id : {user.Id}");
// Console.WriteLine($"Name : {user.FirstName} {user.LastName}");
// Console.WriteLine($"Phone : {user.PhoneNumber}");

// update
// var user = efDbContext.Users.FirstOrDefault();
// user.PhoneNumber = "11223344556";
// efDbContext.Users.Update(user);
// efDbContext.SaveChanges();

// DELETE
// var user = efDbContext.Users.FirstOrDefault();
// efDbContext.Users.Remove(user);
// efDbContext.SaveChanges();

