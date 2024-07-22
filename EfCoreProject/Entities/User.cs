using System.Collections.Generic;

namespace EfCoreProject.Entities;

public class User
{
    public long Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    
    public string? PhoneNumber { get; set; }


    public ICollection<Role> Roles { get; set; }
}   