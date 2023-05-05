using EFCoreDemo.Data;
using EFCoreDemo.Entities;
using Microsoft.EntityFrameworkCore;

using var efDbContext = new EFDbContext();

// Create a new one 
// var user = new User()
// {
//     FirstName = "Sakura",
//     LastName = "Rain",
//     PhoneNumber = "12345678901",
//     Email = "1234@cc.com"
// };
// var role = new Role()
// {
//     RoleName = "Admin",
// };
//
// var role1 = new Role()
// {
//     RoleName = "Customer",
// };
// user.Roles = new List<Role>() { role, role1 };
// efDbContext.Add(user);
// efDbContext.Users.Add(user);

// query the result
// var user = efDbContext.Users.Include(x =>x.Roles)
//     .FirstOrDefault();
// Console.WriteLine($"Id : {user.Id}");
// Console.WriteLine($"Name : {user.FirstName} {user.LastName}");
// Console.WriteLine($"Phone : {user.PhoneNumber}");
// Console.WriteLine($"Email : {user.Email}");

// update
// var user = efDbContext.Users.FirstOrDefault();
// user.FirstName = "Oliver";
// user.LastName = "Stark";
// user.PhoneNumber = "111111";
// user.Email = "111111@cc.com";
// efDbContext.Users.Update(user);

// DELETE
var user = efDbContext.Users.FirstOrDefault();
efDbContext.Users.Remove(user);
efDbContext.SaveChanges();


// 保存到数据库中
efDbContext.SaveChanges();