using Domain.Aggregates.Users;

namespace Domain.Abstractions.Repositories.Users;

public interface IUserRepository : IRepositoryBase<User, string>
{

    Task<User> GetByEmailAsync(string email, CancellationToken ct = default);
}
