using RabbitMQ.Client;
using System;
using System.Text;

namespace Send
{
    class Send
    {
        public static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();

            channel.QueueDeclare(queue: "Hello", durable: false,
                        exclusive: false, autoDelete: false,
                        arguments: null);
            var msg = "Hello world!!";
            var body = Encoding.UTF8.GetBytes(msg);

            channel.BasicPublish(exchange: "", routingKey: "Hello",
                        basicProperties: null, body: body);

            Console.WriteLine($"[x] Sent {msg}");

            Console.WriteLine("Pres [enter] to exit.");
            Console.ReadLine();
        }
    }
}
