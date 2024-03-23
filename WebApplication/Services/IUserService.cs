namespace WebApplication.Services;

public interface IUserService
{
    Task<string> GetRandomUserName();
    Task<IReadOnlyList<User>> GetUsers();
}