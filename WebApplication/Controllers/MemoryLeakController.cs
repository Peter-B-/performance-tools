using System.Collections.Concurrent;
using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers;

[ApiController]
public class MemoryLeakController(ILogger<MemoryLeakController> logger) : ControllerBase
{
    private static readonly ConcurrentDictionary<string, byte[]> cache = new();

    /// <summary>
    ///     Allocates a 16 kiB string
    /// </summary>
    [HttpGet("/allocate")]
    public async Task<string> Allocation()
    {
        var text = new string('A', 1 << 14);

        return text[..3];
    }

    /// <summary>
    ///     Stores 16 kiB in static cache dictionary.
    /// </summary>
    [HttpGet("/leak")]
    public async Task<string> Leak()
    {
        var id = Random.Shared.Next(0, 100000).ToString();

        cache.GetOrAdd(id, _ => new byte[1 << 14]);

        return "abc";
    }
}