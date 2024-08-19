using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using SharedLibraly;

class ClientMessageSender
{
    static async Task Main(string[] args)
    {
        var client = new HttpClient();
        var content = new StringContent(
            Newtonsoft.Json.JsonConvert.SerializeObject(new { Timestamp = DateTime.UtcNow.AddHours(3), Content = "Hello from Client 1" }),
            Encoding.UTF8,
            "application/json");

        var response = await client.PostAsync($"https://localhost:{ClientSettings.PORT}/api/Messages", content);
        Console.WriteLine($"Server response: {response.StatusCode}");
    }
}
