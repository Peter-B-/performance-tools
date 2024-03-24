using System.Collections.Concurrent;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers;

[ApiController]
public class MemoryLeakController(ILogger<MemoryLeakController> logger) : ControllerBase
{
    private static readonly ConcurrentDictionary<string, byte[]> cache = new();

    /// <summary>
    ///     Allocates a 16 kiB byte array
    /// </summary>
    [HttpGet("/alloc")]
    public string Allocation()
    {
        var array = new byte[1 << 14];

        Encoding.UTF8.GetBytes("abc", array);

        return Encoding.UTF8.GetString(array.AsSpan(0, 3));
    }

    /// <summary>
    ///     Stores 16 kiB in static cache dictionary.
    /// </summary>
    [HttpGet("/leak")]
    public string Leak()
    {
        var id = Random.Shared.Next(0, 100000).ToString();

        cache.GetOrAdd(id, _ => new byte[1 << 14]);

        logger.LogInformation("Storing {Count} items", cache.Count);

        return "abc";
    }
}