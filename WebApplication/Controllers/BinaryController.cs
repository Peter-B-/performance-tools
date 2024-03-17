using System.Buffers.Binary;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class BinaryController : ControllerBase
{
    [HttpGet("bigEndian/tick")]
    public IActionResult GetUtcTick()
    {
        var data = new byte[8];
        BinaryPrimitives.WriteInt64BigEndian(data, DateTime.UtcNow.Ticks);
        return File(data, "application/octet-stream");
    }

    [HttpGet("data/1k")]
    public IActionResult GetData1k()
    {
        var data = new byte[1 << 10];
        Random.Shared.NextBytes(data);

        BinaryPrimitives.WriteInt64BigEndian(data, DateTime.UtcNow.Ticks);
        return File(data, "application/octet-stream");
    }

}