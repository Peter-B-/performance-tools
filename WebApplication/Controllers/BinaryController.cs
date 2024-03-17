using System.Buffers.Binary;
using System.Collections.Concurrent;
using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class BinaryController : ControllerBase
{
    [HttpGet("data/1k")]
    public IActionResult GetData1k()
    {
        var data = new byte[1 << 10];
        Random.Shared.NextBytes(data);

        BinaryPrimitives.WriteInt64BigEndian(data, DateTime.UtcNow.Ticks);
        return File(data, "application/octet-stream");
    }

    [HttpGet("bigEndian/tick")]
    public IActionResult GetUtcTick()
    {
        var data = new byte[8];
        BinaryPrimitives.WriteInt64BigEndian(data, DateTime.UtcNow.Ticks);
        return File(data, "application/octet-stream");
    }
}

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