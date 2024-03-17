namespace WorkerService;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = Host.CreateApplicationBuilder(args);
        builder.Services.AddHostedService<Worker>();
        builder.Services.AddHttpClient();

        var host = builder.Build();
        host.Run();
    }
}