using MessageWebService.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
[Route("api/[controller]")]
public class MessagesController : ControllerBase
{
    private readonly AppDbContext _context;

    public MessagesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<ActionResult> SendMessage([FromBody] Message message)
    {
        message.Timestamp = DateTime.UtcNow;
        _context.Messages.Add(message);
        await _context.SaveChangesAsync();
        return Ok();
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Message>>> GetMessages([FromQuery] DateTime from, [FromQuery] DateTime to)
    {
        var messages = await _context.Messages
            .Where(m => m.Timestamp >= from && m.Timestamp <= to)
            .ToListAsync();
        return Ok(messages);
    }
}
