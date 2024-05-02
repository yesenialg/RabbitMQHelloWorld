using RabbitMQ.Client;
using System.Text;

var factory = new ConnectionFactory
{
    HostName = "localhost",
    UserName = "admin",
    Password = "admin"
};

using (var connection = factory.CreateConnection())
using (var channel = connection.CreateModel()) 
{
    channel.QueueDeclare("udemyQueue", false, false, false, null);

    var message = "Bienvenido";
    var body = Encoding.UTF8.GetBytes(message);

    channel.BasicPublish("", "udemyQueue", null, body);
    Console.WriteLine("El mensaje fue enviado {0}", message);
}

Console.WriteLine("Presiona [Enter] para salir de la aplicación");
Console.ReadLine();