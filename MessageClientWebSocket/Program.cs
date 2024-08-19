using MessageWebService.API.Models;
using Microsoft.AspNetCore.SignalR.Client;
using SharedLibraly;



class ClientMessageListner
{
    static async Task Main(string[] args)
    {
        var connection = new HubConnectionBuilder()
            .WithUrl($"https://localhost:{ClientSettings.PORT}/messagesHub")
            .Build();
        connection.On<Message>("ReceiveMessage", message =>
        {
            Console.WriteLine($"{message.Timestamp.ToShortTimeString()}   Получено сообщение: {message.Content}");
        });

        await connection.StartAsync();
        Console.WriteLine("Соединение установлено. В ожидании сообщений...");

        Console.ReadLine();
    }
}
