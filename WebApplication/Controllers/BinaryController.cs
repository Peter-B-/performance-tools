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
public class MemoryLeakController : ControllerBase
{
    private static readonly ConcurrentDictionary<string, string> _cache = new ConcurrentDictionary<string, string>();

    [HttpGet("/leak")]
    public string Leak1()
    {
        var id = DateTime.UtcNow.Ticks.ToString(CultureInfo.InvariantCulture);

        return
            _cache.GetOrAdd(id, _ => new string('c', 5 << 10))
                .Substring(0, 5);
    }
}