namespace Presentation.Api.Models;

public sealed record RegisterUserRequest
(
    string FirstName,
    string LastName,
    string Username,
    string Email
);
