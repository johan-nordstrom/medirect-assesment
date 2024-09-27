using System.Text.Json;
using System.Threading.Tasks;
using Medirect_Assesment.Models;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Medirect_Assesment.Services
{
    public class RabbitMQService : IMessageQueueService
    {
        private IConnection _connection;
        private IChannel _channel;

        public RabbitMQService()
        {
            //var factory = new ConnectionFactory() { HostName = "localhost" };
            //_connection = await factory.CreateConnectionAsync();
            //_channel = await _connection.CreateChannelAsync();
            //await _channel.QueueDeclareAsync(queue: "trades", durable: false, exclusive: false, autoDelete: false,
            //    arguments: null);
            Startup();
        }

        private async void Startup()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            _connection = await factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();
            await _channel.QueueDeclareAsync(queue: "trades", durable: false, exclusive: false, autoDelete: false,
                arguments: null);
        }

        public async Task PublishTradeMessageAsync(Trade trade)
        {
            var message = JsonSerializer.Serialize(trade);
            var body = System.Text.Encoding.UTF8.GetBytes(message);

            await _channel.BasicPublishAsync(exchange: "", routingKey: "trades", mandatory: true, cancellationToken: null, body: body);

            //return Task.CompletedTask;
            await Task.CompletedTask;
        }
    }
}