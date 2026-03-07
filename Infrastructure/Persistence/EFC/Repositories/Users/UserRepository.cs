using Domain.Abstractions.Repositories.Users;
using Domain.Aggregates.Users;
using Infrastructure.Persistence.EFC.Contexts;
using Infrastructure.Persistence.EFC.Entities;
using Infrastructure.Persistence.EFC.Factories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EFC.Repositories.Users;

internal class UserRepository(DataContext context) : RepositoryBase<User, string, UserEntity, DataContext>(context), IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email, CancellationToken ct = default)
    {
        var entity = await Set.FirstOrDefaultAsync(u => u.Email == email, ct);
        return entity is not null ? ToModel(entity) : null;
    }

    protected override UserEntity ToEntity(User model) =>  UserEntityFactory.Create(model);

    protected override User ToModel(UserEntity entity) => User.FromEntity(
        entity.Id,
        entity.FirstName,
        entity.LastName,
        entity.Username,
        entity.Email,
        entity.CreatedAt,
        entity.ModifiedAt
    );

}
