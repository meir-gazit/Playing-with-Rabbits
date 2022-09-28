using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

var host = "localhost";
var factory = new ConnectionFactory() { HostName = host };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare("QueueTest", false, false, false, null);
    var consumer = new EventingBasicConsumer(channel);
    consumer.Received += (model, ea) =>
    {
        var body = ea.Body.ToArray(); ;
        var message = Encoding.UTF8.GetString(body);
        Console.WriteLine("Recive message {0}...", message);
    };

    Console.WriteLine("Press to Exit.");
    Console.ReadLine();
}
