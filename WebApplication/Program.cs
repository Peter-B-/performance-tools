
namespace WebApplication;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);

        builder.Services.AddControllers();
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.RoutePrefix = "";
            c.EnableTryItOutByDefault();
        });

        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}