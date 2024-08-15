namespace MessageWebService.API.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
        public int SequenceNumber { get; set; }
    }
}
