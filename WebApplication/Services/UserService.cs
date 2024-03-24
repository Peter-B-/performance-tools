using Faker;

namespace WebApplication.Services;

class UserService : IUserService
{
    private readonly IReadOnlyList<User> users = GenerateUsers(10000);

    public async Task<string> GetRandomUserName() => users[Random.Shared.Next(users.Count)].UserName;

    public async Task<IReadOnlyList<User>> GetUsers() => users;

    private static IReadOnlyList<User> GenerateUsers(int numberOfUsers) =>
        Enumerable.Range(1, numberOfUsers)
            .Select(i => new User(
                        $"user {i}",
                        Name.First(),
                        Name.Last(),
                        Address.StreetAddress(),
                        Address.City(),
                        Address.Country()
                    ))
            .ToList();
}