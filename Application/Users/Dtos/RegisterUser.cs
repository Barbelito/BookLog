namespace Application.Users.Dtos;

public sealed record RegisterUser
(
    string FirstName,
    string LastName,
    string Username,
    string Email
);
