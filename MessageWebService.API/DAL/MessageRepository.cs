using MessageWebService.API.Models;
using Npgsql;

namespace MessageWebService.API.DAL
{
    public class MessageRepository
    {
        private readonly string _connectionString;

        public MessageRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddMessage(Message message)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "INSERT INTO Messages (Content, Timestamp) VALUES (@content, @timestamp)";
                    command.Parameters.AddWithValue("@content", message.Content);
                    command.Parameters.AddWithValue("@timestamp", message.Timestamp);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Message> GetMessages(DateTime from, DateTime to)
        {
            var messages = new List<Message>();

            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Messages WHERE Timestamp >= @from AND Timestamp <= @to ORDER BY Timestamp ASC";
                    command.Parameters.AddWithValue("@from", from);
                    command.Parameters.AddWithValue("@to", to);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            messages.Add(new Message
                            {
                                Id = reader.GetInt32(0),
                                Content = reader.GetString(1),
                                Timestamp = reader.GetDateTime(2),
                            });
                        }
                    }
                }
            }

            return messages;
        }
    }
}
