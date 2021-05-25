using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace NewsProject.Receiver
{
    class Program
    {
        static void Main(string[] args)
        {

            Receiver receiver = new Receiver();
            receiver.Receive();
        }
    }
}
