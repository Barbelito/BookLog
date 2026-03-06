using Application.Users.Dtos;

namespace Application.Users.Abstractions;

public interface IUserService
{
    Task<bool> RegisterUserAsync(RegisterUser dto, CancellationToken ct = default);
}
