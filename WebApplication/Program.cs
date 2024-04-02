
using WebApplication.Services;

namespace WebApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        builder.Services.AddSingleton<IUserService, UserService>();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.RoutePrefix = "";
            c.SwaggerEndpoint("../swagger/v1/swagger.json", "My API V1");
            c.EnableTryItOutByDefault();
            c.DisplayRequestDuration();
        });

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}