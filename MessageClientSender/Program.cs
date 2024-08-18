using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

class Client1
{
    static async Task Main(string[] args)
    {
        var client = new HttpClient();
        var content = new StringContent(
            Newtonsoft.Json.JsonConvert.SerializeObject(new { Timestamp = DateTime.UtcNow.AddHours(3), Content = "Hello from Client 1" }),
            Encoding.UTF8,
            "application/json");

        var response = await client.PostAsync("https://localhost:55059/api/Messages", content);
        Console.WriteLine($"Server response: {response.StatusCode}");
    }
}
