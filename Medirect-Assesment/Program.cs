// See https://aka.ms/new-console-template for more information

using System.Text;
using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

Console.WriteLine("Hello, World!");


var factory = new ConnectionFactory() { HostName = "localhost" };
using (var connection = await factory.CreateConnectionAsync())
using (var channel = await connection.CreateChannelAsync())
{
    await channel.QueueDeclareAsync(queue: "trades", durable: false, exclusive: false, autoDelete: false, arguments: null);

    var consumer = new AsyncEventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray();
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine($"Received trade: {message}");
    };
    await channel.BasicConsumeAsync(queue: "trades", autoAck: true, consumer: consumer);

    Console.WriteLine("Press [enter] to exit.");
    Console.ReadLine();
}