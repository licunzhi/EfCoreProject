namespace EfCoreProject.Entities;

public class Role
{
    public long Id { get; set; }
    public string RoleName { get; set; } = null!;

    public User user { get; set; }
    public long UserId { get; set; }
}