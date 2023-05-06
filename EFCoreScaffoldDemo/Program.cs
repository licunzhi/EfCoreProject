using EFCoreScaffoldDemo.Data;

using var efDbContext = new EFCoreContext();

var user = efDbContext.Users.FirstOrDefault();
Console.WriteLine($"Id : {user.Id}");
Console.WriteLine($"Name : {user.FirstName} {user.LastName}");
Console.WriteLine($"Phone : {user.PhoneNumber}");
Console.WriteLine($"Address : {user.Address}");