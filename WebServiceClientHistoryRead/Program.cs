using System;
using System.Net.Http;
using System.Threading.Tasks;

class Client3
{
    static async Task Main(string[] args)
    {
        var client = new HttpClient();
        var from = DateTime.UtcNow.AddHours(3).AddMinutes(-10).ToString("o");
        var to = DateTime.UtcNow.AddHours(3).ToString("o");

        var response = await client.GetStringAsync($"https://localhost:55059/api/Messages?from={from}&to={to}");
        Console.WriteLine("Сообщение за последние 10 минут:");
        Console.WriteLine(response);
    }
}
