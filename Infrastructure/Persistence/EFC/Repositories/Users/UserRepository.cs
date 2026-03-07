using Domain.Abstractions.Repositories.Users;
using Domain.Aggregates.Users;
using Infrastructure.Persistence.EFC.Contexts;
using Infrastructure.Persistence.EFC.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.EFC.Repositories.Users;

internal class UserRepository(DataContext context) : RepositoryBase<User, string, UserEntity, DataContext>(context), IUserRepository
{
    public async Task<User?> GetByEmailAsync(string email, CancellationToken ct = default)
    {
        var entity = await Set.FirstOrDefaultAsync(u => u.Email == email, ct);
        return entity is not null ? ToModel(entity) : null;
    }

    protected override UserEntity ToEntity(User model)
    {
        var entity = new UserEntity
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Username = model.Username,
            Email = model.Email
        };
        return entity;
    }

    protected override User ToModel(UserEntity entity)
    {
        throw new NotImplementedException();
    }
}
