using System.Buffers.Binary;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers;

[ApiController]
[Route("[controller]")]
public class BinaryController : ControllerBase
{
    [HttpGet("bigEndian/tick")]
    public async Task<IActionResult> GetUtcTick()
    {
        var data = new byte[8];
        BinaryPrimitives.WriteInt64BigEndian(data, DateTime.UtcNow.Ticks);
        await Task.Delay(500);
        return File(data, "application/octet-stream");
    }
}