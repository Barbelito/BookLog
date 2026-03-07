using Application.Common.Results;
using Application.Users.Abstractions;
using Application.Users.Dtos;
using Domain.Abstractions.Repositories.Users;
using Domain.Aggregates.Users;

namespace Application.Users.Services;

public sealed class UserService(IUserRepository userRepository) : IUserService
{
    public async Task<Result<IReadOnlyList<UserDto>>> GetUserAsync(CancellationToken ct = default)
    {
        var users = await userRepository.GetAllAsync(ct);

        if (users is null)
            return Result<IReadOnlyList<UserDto>>.Failure(
                new Error("User.FetchFailed", "Failed to retrieve users.", 500)
            );

        var dtos = users.Select(UserDto.FromModel).ToList();
        return Result<IReadOnlyList<UserDto>>.Success(dtos);
    }

    public async Task<Result<UserDto>> GetUserByEmailAsync(string email, CancellationToken ct = default)
    {
        var user = await userRepository.GetByEmailAsync(email, ct);

        if (user is null)
            return Result<UserDto>.Failure(
                new Error("User.NotFound", "User not found.", 404)
            );

        return Result<UserDto>.Success(UserDto.FromModel(user));
    }

    public async Task<Result<UserDto>> GetUserByIdAsync(string id, CancellationToken ct = default)
    {
        var user = await userRepository.GetByIdAsync(id, ct);

        if (user is null)
            return Result<UserDto>.Failure(
                new Error("User.NotFound", "User not found.", 404)
            );

        return Result<UserDto>.Success(UserDto.FromModel(user));
    }

    public async Task<Result<UserDto>> RegisterUserAsync(RegisterUser dto, CancellationToken ct = default)
    {
        if (dto is null)
            return Result<UserDto>.Failure(
                new Error("User.InvalidInput", "RegisterUser is missing.", 400)
            );

        var existingUser = await userRepository.GetByEmailAsync(dto.Email, ct);

        if (existingUser is not null)
            return Result<UserDto>.Failure(
                new Error("User.EmailExists", "User with same email already exists.", 409)
            );

        var user = User.Create(dto.FirstName, dto.LastName, dto.Username, dto.Email);

        var createdUser = await userRepository.AddAsync(user, ct);

        if (createdUser is null)
            return Result<UserDto>.Failure(
                new Error("User.CreateFailed", "Failed to register user.", 500)
            );

        return Result<UserDto>.Success(UserDto.FromModel(createdUser));
    }
}
