namespace Application.Users.Dtos;

public sealed record UserDto
(
    string Id,
    string FirstName,
    string LastName,
    string Username,
    string Email,
    DateTime CreatedAt,
    DateTime ModifiedAt
)
{
    public static UserDto FromModel(Domain.Aggregates.Users.User user)
        => new(
            user.Id,
            user.FirstName,
            user.LastName,
            user.Username,
            user.Email,
            user.CreatedAt,
            user.ModifiedAt
        );
}
