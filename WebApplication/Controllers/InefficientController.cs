using Microsoft.AspNetCore.Mvc;
using WebApplication.Services;

namespace WebApplication.Controllers;

[ApiController]
public class InefficientController(IUserService userService) : ControllerBase
{
    [HttpGet("/users/random")]
    public async Task<User> GetRandomUser()
    {
        var userName = await userService.GetRandomUserName();
        var users = await userService.GetUsers();

        return users.Single(u => u.UserName == userName);
    }
}