using MessageWebService.API.Models;
using Microsoft.AspNetCore.SignalR;

namespace MessageWebService.API.Hubs
{
    public class MessageHub : Hub
    {
        /// <summary>
        /// Метод отправки сообщения всем клиентам, подключенным к хабу
        /// </summary>
        /// <param name="message"></param>
        /// <returns></returns>
        public async Task SendMessage(Message message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
