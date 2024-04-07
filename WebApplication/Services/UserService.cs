using Faker;

namespace WebApplication.Services;

internal class UserService : IUserService
{
    private static readonly string UserFilePath = 
        Path.Combine(@"c:\temp\Vortrag\", "data", $"users {DateTime.Now:HHmmss}.csv");
    private static readonly int NoOfUsers = 5000;

    public async Task<string> GetRandomUserName() => 
        GetUserName(Random.Shared.Next(NoOfUsers) + 1);

    public async Task<IReadOnlyList<User>> GetUsers()
    {
        if (!File.Exists(UserFilePath))
            await CreateUserFile();

        var users = new List<User>(NoOfUsers);
        await foreach (var line in File.ReadLinesAsync(UserFilePath))
        {
            var parts = line.Split(",");
            users.Add(new User(parts[0], parts[1], parts[2], parts[3], parts[4], parts[5]));
        }

        return users;
    }

    private static async Task CreateUserFile()
    {
        Directory.CreateDirectory(Path.GetDirectoryName(UserFilePath)!);
    
            var users =
                GenerateUsers(NoOfUsers)
                    .Select(u => string.Join(",", u.UserName, u.FirstName, u.LastName, u.Address, u.City, u.Country));
            await File.WriteAllLinesAsync(UserFilePath, users);
        
    }

    private static IEnumerable<User> GenerateUsers(int numberOfUsers)
    {
        return Enumerable.Range(1, numberOfUsers)
            .Select(i => new User(
                GetUserName(i),
                Name.First(),
                Name.Last(),
                Address.StreetAddress(),
                Address.City(),
                Address.Country()
            ));
    }

    private static string GetUserName(int i)
    {
        return $"user {i}";
    }
}