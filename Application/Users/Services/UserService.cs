using Application.Common.Validators;
using Application.Users.Abstractions;
using Application.Users.Dtos;
using Domain.Abstractions.Repositories.Users;
using Domain.Aggregates.Users;
using System.Security.Cryptography.X509Certificates;

namespace Application.Users.Services;

public sealed class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<bool> RegisterUserAsync(RegisterUser dto, CancellationToken ct = default)
    {
        if(dto is null)
            throw new ArgumentException("RegisterUser is missing.");

        var existingUser = await userRepository.GetByEmailAsync(dto.Email, ct);
        if (existingUser is not null)
            throw new ArgumentException("User with same email already exists.");

        var user = User.Create(dto.FirstName, dto.LastName, dto.Username, dto.Email);

        var id = await userRepository.AddAsync(user, ct);
        return !string.IsNullOrWhiteSpace(id);
    }
}

