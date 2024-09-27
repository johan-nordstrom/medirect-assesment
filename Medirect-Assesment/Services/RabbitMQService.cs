// TradingMicroservice/Services/RabbitMQService.cs
using System.Text.Json;
using System.Threading.Tasks;
using RabbitMQ.Client;
using TradingMicroservice.Models;

namespace Medirect_Assesment.Services
{
    public class RabbitMQService : IMessageQueueService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQService()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "trades", durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public Task PublishTradeMessageAsync(Trade trade)
        {
            var message = JsonSerializer.Serialize(trade);
            var body = System.Text.Encoding.UTF8.GetBytes(message);

            _channel.BasicPublish(exchange: "", routingKey: "trades", basicProperties: null, body: body);

            return Task.CompletedTask;
        }
    }
}