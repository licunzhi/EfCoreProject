using System;
using System.Linq;
using EFCoreScaffold.Data;

using var efDbContext = new EFCoreScaffoldContext();

var user = efDbContext.Users.FirstOrDefault();
Console.WriteLine($"Id : {user.Id}");
Console.WriteLine($"Name : {user.FirstName} {user.LastName}");
Console.WriteLine($"Phone : {user.PhoneNumber}");
Console.WriteLine($"Address : {user.Address}");
Console.WriteLine($"CardId : {user.CardId}");
Console.WriteLine("hello");