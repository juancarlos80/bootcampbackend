using Newtonsoft.Json.Linq;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;

namespace StatsService
{
    class Program
    {
        private const string DELETE_QUEUE = "deleteQueue";        
        private const string UPDATE_ATTENDANCE_QUEUE = "UpdateAttendanceQueue";

        private const string USERNAME = "guest";
        private const string PASSWORD = "guest";
        private const string HOSTNAME = "localhost";
        private const int PORT = 5672;

        static void Main(string[] args)
        {

            var factory = new ConnectionFactory()
            {
                HostName = HOSTNAME,
                Port = PORT,
                UserName = USERNAME,
                Password = PASSWORD
            };
            var rabbitMqConnection = factory.CreateConnection();

            
            ListenDeleteUser(rabbitMqConnection);
            ListenUpdateAttendances(rabbitMqConnection);            

            Console.ReadLine();
        }

        public static void ListenDeleteUser(IConnection rabbitMqConnection)
        {
            var rabbitMqChannelDelete = rabbitMqConnection.CreateModel();
            rabbitMqChannelDelete.QueueDeclare(queue: DELETE_QUEUE,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

            rabbitMqChannelDelete.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            var consumer = new EventingBasicConsumer(rabbitMqChannelDelete);
            consumer.Received += (model, args) =>
            {
                var body = args.Body;
                var idUser = Encoding.UTF8.GetString(body.ToArray());

                ApiService.DeleteAttendances(idUser);
                
                    rabbitMqChannelDelete.BasicAck(
                        deliveryTag: args.DeliveryTag, 
                        multiple: false);
                
                
            };
            rabbitMqChannelDelete.BasicConsume(queue: DELETE_QUEUE,
                                         autoAck: false,
                                         consumer: consumer);
        }

        public static void ListenUpdateAttendances(IConnection rabbitMqConnection)
        {
            var rabbitMqChannelInsert = rabbitMqConnection.CreateModel();
            rabbitMqChannelInsert.QueueDeclare(queue: UPDATE_ATTENDANCE_QUEUE,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

            rabbitMqChannelInsert.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);

            var consumerI = new EventingBasicConsumer(rabbitMqChannelInsert);
            consumerI.Received += (model, args) =>
            {
                var body = args.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());                

                ApiService.UpdateAttendance(message);
                
                    rabbitMqChannelInsert.BasicAck(
                        deliveryTag: args.DeliveryTag, 
                        multiple: false);
                
                
            };
            rabbitMqChannelInsert.BasicConsume(queue: UPDATE_ATTENDANCE_QUEUE,
                                         autoAck: false,
                                         consumer: consumerI);
        }
    }
}
