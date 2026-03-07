using Application.Common.Results;
using Application.Users.Dtos;

namespace Application.Users.Abstractions;

public interface IUserService
{
    Task<Result<UserDto>> RegisterUserAsync(RegisterUser dto, CancellationToken ct = default);
    Task<Result<UserDto>> GetUserByIdAsync(string id, CancellationToken ct = default);
    Task<Result<UserDto>> GetUserByEmailAsync(string email, CancellationToken ct = default);
    Task<Result<IReadOnlyList<UserDto>>> GetUserAsync(CancellationToken ct = default);
}
