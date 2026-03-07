using Application.Common.Results;
using Application.Users.Dtos;
using Domain.Aggregates.Users;

namespace Application.Users.Abstractions;

public interface IUserService
{
    Task<Result> RegisterUserAsync(RegisterUser dto, CancellationToken ct = default);
    Task<Result<User?>> GetUserByIdAsync(string id, CancellationToken ct = default);
    Task<Result<User?>> GetUserByEmailAsync(string email, CancellationToken ct = default);
    Task<Result<IReadOnlyList<User>>> GetUserAsync(CancellationToken ct = default);

}
