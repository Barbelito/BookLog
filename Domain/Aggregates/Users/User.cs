namespace Domain.Aggregates.Users;

public sealed class User
{
    public string Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Username { get; private set; }
    public string Email { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime ModifiedAt { get; private set; }

    private static string Required(string value, string fieldName)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException($"{fieldName} cannot be null or empty.", fieldName);

        return value.Trim();
    }


    private static string NormalizeEmail(string value)
    {
        var normalized = Required(value, nameof(value)).ToLowerInvariant();

        if (!normalized.Contains("@"))
            throw new ArgumentException("Email must contain '@'.", nameof(value));

        return normalized;
    }

    private User(string id, string firstName, string lastName, string username, string email)
    {
        Id = Required(id, nameof(id));
        FirstName = Required(firstName, nameof(firstName));
        LastName = Required(lastName, nameof(lastName));
        Username = Required(username, nameof(username));
        Email = NormalizeEmail(email);
        CreatedAt = DateTime.UtcNow;
        ModifiedAt = DateTime.UtcNow;
    }
    private User(
    string id,
    string firstName,
    string lastName,
    string username,
    string email,
    DateTime createdAt,
    DateTime modifiedAt)
    {
        Id = Required(id, nameof(id));
        FirstName = Required(firstName, nameof(firstName));
        LastName = Required(lastName, nameof(lastName));
        Username = Required(username, nameof(username));
        Email = NormalizeEmail(email);
        CreatedAt = createdAt;
        ModifiedAt = modifiedAt;
    }


    public static User Create(string firstName, string lastName, string username, string email)
    {
        var id = Guid.NewGuid().ToString();
        return new User(id, firstName, lastName, username, email);
    }

    public void Update(string firstName, string lastName, string username, string email)
    {
        FirstName = Required(firstName, nameof(firstName));
        LastName = Required(lastName, nameof(lastName));
        Username = Required(username, nameof(username));
        Email = NormalizeEmail(email);
        ModifiedAt = DateTime.UtcNow;
    }
    public static User FromEntity(
    string id,
    string firstName,
    string lastName,
    string username,
    string email,
    DateTime createdAt,
    DateTime modifiedAt)
    {
        return new User(id, firstName, lastName, username, email, createdAt, modifiedAt);
    }

}
