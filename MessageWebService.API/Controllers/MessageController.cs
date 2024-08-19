using MessageWebService.API.DAL;
using MessageWebService.API.Models;
using MessageWebService.API.Hubs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace MessageService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessagesController : ControllerBase
    {
        private readonly MessageRepository _repository;
        private readonly IHubContext<MessageHub> _hubContext;
        private readonly ILogger<MessagesController> _logger;

        public MessagesController(MessageRepository repository, IHubContext<MessageHub> hubContext, ILogger<MessagesController> logger)
        {
            _repository = repository;
            _hubContext = hubContext;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody] Message message)
        {
            message.Timestamp = DateTime.UtcNow.AddHours(3);
            _repository.AddMessage(message);
            _logger.LogInformation("Message added with content: {Content}", message.Content);
            _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
            _logger.LogInformation("Message broadcasted to WebSocket clients.");

            return Ok();
        }

        [HttpGet]
        public IActionResult GetMessages([FromQuery] DateTime from, [FromQuery] DateTime to)
        {
            var messages = _repository.GetMessages(from, to);
            _logger.LogInformation("Messages retrieved from {From} to {To}", from, to);
            return Ok(messages);
        }
    }
}
