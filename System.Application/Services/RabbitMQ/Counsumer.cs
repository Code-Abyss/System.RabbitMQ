
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Application.RabbitMQ.Produser;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace System.Application.RabbitMQ
{

    public class Counsumer: BackgroundService
    {      
        public static void StartCounsumer()
        {

        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = "localhost",
                UserName = "admin",
                Password = "123456"
            };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "invoices", exclusive: false, durable: false, autoDelete: false, arguments: null);

            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                Console.WriteLine($"Message received: {message} From Invoice.RabbitMQ");


            };

            channel.BasicConsume(queue: "invoices", autoAck: true, consumer: consumer);
            return Task.CompletedTask;

        }
    }
}
