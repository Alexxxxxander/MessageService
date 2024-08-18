using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Threading.Tasks;

class Client2
{
    static async Task Main(string[] args)
    {
        var connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:55059/Messages")
            .Build();
        connection.On<string>("ReceiveMessage", message =>
        {
            Console.WriteLine($"Received message: {message}");
        });

        await connection.StartAsync();
        Console.WriteLine("Connection started. Waiting for messages...");

        Console.ReadLine();
    }
}
