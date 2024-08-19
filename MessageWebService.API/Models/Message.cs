namespace MessageWebService.API.Models
{
    public class Message
    {
        public int? Id { get; set; } //можно не передавать айди, он в любом случае заменится в бд
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
