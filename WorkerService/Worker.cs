using System.Buffers;
using System.Buffers.Binary;

namespace WorkerService;

public class Worker : BackgroundService
{
    private readonly IHttpClientFactory httpClientFactory;
    private readonly ILogger<Worker> logger;
    private readonly HttpClient client;

    public Worker(ILogger<Worker> logger, IHttpClientFactory httpClientFactory)
    {
        this.logger = logger;
        this.httpClientFactory = httpClientFactory;

        this.client = httpClientFactory.CreateClient();

    }

    protected override async Task ExecuteAsync(CancellationToken token)
    {
        while (!token.IsCancellationRequested)
        {
            try
            {
                await ReadIntoPoolArray(token);
            }
            catch (TaskCanceledException)
            {
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Failed to read data");
            }

            await Task.Delay(10, token);
        }
    }

    private async Task ReadIntoNewArray(CancellationToken token)
    {
        var data = await client.GetByteArrayAsync("http://localhost:5065/Binary/data/1k", token);

        var ticks = BinaryPrimitives.ReadInt64BigEndian(data);
        var dateTimeUtc = new DateTime(ticks, DateTimeKind.Utc);
        //if (logger.IsEnabled(LogLevel.Information))
        //    logger.LogInformation("Received {length} bytes with time {time}", data.Length, dateTimeUtc);
    }

    private async Task ReadIntoPoolArray(CancellationToken token)
    {
        //var data = ArrayPool<byte>.Shared.Rent(1 << 10);
        var data = new byte[1 << 10];

        try
        {
            await ReadIntoByteArray(token, client, data);

            var ticks = BinaryPrimitives.ReadInt64BigEndian(data);
            var dateTimeUtc = new DateTime(ticks, DateTimeKind.Utc);
            if (logger.IsEnabled(LogLevel.Information))
                logger.LogInformation("Received {length} bytes with time {time}", data.Length, dateTimeUtc);
        }
        finally
        {
            //ArrayPool<byte>.Shared.Return(data);
        }
    }

    private static async Task ReadIntoByteArray(CancellationToken token, HttpClient client, byte[] data)
    {
        var response = await client.GetAsync("http://localhost:5065/Binary/data/1k", token);
        response.EnsureSuccessStatusCode();

        var stream = await response.Content.ReadAsStreamAsync(token);
        using var memoryStream = new MemoryStream(data);
        await stream.CopyToAsync(memoryStream, token);
    }
}