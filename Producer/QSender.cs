using RabbitMQ.Client;
using System.Text;

var host = "localhost";
var factory = new ConnectionFactory() { HostName = host };
using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel())
{
    channel.QueueDeclare("QueueTest", false, false, false, null);
    var message = "Test Queue Successful";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish("", "QueueTest", null, body);
    Console.WriteLine("Sent message {0}...", message);
    Console.WriteLine("Press to Exit.");
    Console.ReadLine();
}
