using Domain.Aggregates.Users;
using Infrastructure.Persistence.EFC.Entities;

namespace Infrastructure.Persistence.EFC.Factories;

public static class UserEntityFactory
{
    public static UserEntity Create() => new UserEntity();
    public static UserEntity Create(User model)
    {
        return new UserEntity
        {
            Id = model.Id,
            FirstName = model.FirstName,
            LastName = model.LastName,
            Username = model.Username,
            Email = model.Email,
            CreatedAt = model.CreatedAt,
            ModifiedAt = model.ModifiedAt
        };
    }

}
