using Application.Users.Dtos;

namespace Application.Users.Factories;

public static class UserFactory
{
    public static RegisterUser Create(string firstName, string lastName, string username, string email) => new(firstName, lastName, username, email);

}
