using Application.Common.Validators;
using Application.Users.Abstractions;
using Application.Users.Dtos;
using Domain.Abstractions.Repositories;
using Domain.Aggregates.Users;
using System.Security.Cryptography.X509Certificates;

namespace Application.Users.Services;

public sealed class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<bool> RegisterUserAsync(RegisterUser dto, CancellationToken ct = default)
    {
        var existingUser = await userRepository.GetByEmailAsync(dto.Email, ct);
        ModelValidator.ValidateModel(existingUser, "User with same email already exists.");

        var user = User.Create(dto.FirstName, dto.LastName, dto.Username, dto.Email);

        var createdUser = await userRepository.CreateAsync(user, ct);
        return createdUser;
    }
}
