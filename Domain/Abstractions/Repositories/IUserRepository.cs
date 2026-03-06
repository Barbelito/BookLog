using Domain.Aggregates.Users;

namespace Domain.Abstractions.Repositories;

public interface IUserRepository
{
    Task<bool> CreateAsync(User model, CancellationToken ct = default);

    Task<User> GetByEmailAsync(string email, CancellationToken ct = default);
}
