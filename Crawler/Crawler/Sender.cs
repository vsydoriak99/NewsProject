using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Text;

namespace NewsProject.Crawler
{
    public class Sender
    {
        public void Send(NewsModel news)
        {

            // встановлення зв"язку з брокером на локальній машині (налаштування сокетів, встановлення протоколу, аутентифікація)
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                // вся комунікація відбувається через чергу
                // створення черги, якщо такої ще немає, або використання існуючої
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);


                var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(news));
                var properties = channel.CreateBasicProperties();
                properties.Persistent = true;

                channel.BasicPublish(exchange: "",
                                     routingKey: "hello",
                                     basicProperties: properties,
                                     body: body);
                Console.WriteLine(" [x] Sent \n {0}", news);
            }

            Console.WriteLine(" Press [enter] to exit.");
        }
    }
}
