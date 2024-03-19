using System.Collections.Concurrent;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers;

[ApiController]
public class MemoryLeakController(ILogger<MemoryLeakController> logger) : ControllerBase
{
    private static readonly ConcurrentDictionary<string, byte[]> _cache = new ConcurrentDictionary<string, byte[]>();

    [HttpGet("/leak")]
    public string Leak1()
    {
        for (var i = 0; i < 10; i++)
        {
            var id = Random.Shared.Next(0, 100000).ToString();

            _cache.GetOrAdd(id, _ => new byte[1 << 14]);
        }

        logger.LogInformation("Storing {Count} items", _cache.Count);

        return "abc";
    }
}