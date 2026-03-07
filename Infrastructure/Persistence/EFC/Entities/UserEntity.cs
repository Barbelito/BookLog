namespace Infrastructure.Persistence.EFC.Entities;

public sealed class UserEntity
{
    public string Id { get; set; } = null!;
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;

    public DateTime CreatedAt { get; set; }
    public DateTime ModifiedAt { get; set; }
}