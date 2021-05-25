
using NewsProject.DAL.DTO;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Configuration;
using System.Text;

namespace NewsProject.Receiver
{
    public class Receiver
    {
        public void Receive()
        {
            var factory = new ConnectionFactory() { HostName = ConfigurationManager.AppSettings.Get("RabbitHost") };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // назва черги має співпадати
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var consumer = new EventingBasicConsumer(channel);




                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.Span;
                    var x = Encoding.UTF8.GetString(body);
                    NewsDTO n = JsonConvert.DeserializeObject<NewsDTO>(Encoding.UTF8.GetString(body));
                    DBHelper.GetNewsRepository().Create(n);
                    Console.WriteLine(" [x] Received \n {0}", x);
                    Console.WriteLine(n.Description);
                };

                //// споживач працює неперервно
                channel.BasicConsume(queue: "hello",
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
