using MessageWebService.API.Models;
using Microsoft.AspNetCore.SignalR;

namespace MessageWebService.API.Hubs
{
    public class MessageHub : Hub
    {
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
