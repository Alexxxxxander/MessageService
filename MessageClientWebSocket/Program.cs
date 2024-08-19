using Microsoft.AspNetCore.SignalR.Client;
using SharedLibraly;

class ClientMessageListner
{
    static async Task Main(string[] args)
    {
        var connection = new HubConnectionBuilder()
            .WithUrl($"https://localhost:{ClientSettings.PORT}/Messages")
            .Build();
        connection.On<string>("ReceiveMessage", message =>
        {
            Console.WriteLine($"Получено сообщение: {message}");
        });

        await connection.StartAsync();
        Console.WriteLine("Соединение установлено. В ожидании сообщений...");

        Console.ReadLine();
    }
}
