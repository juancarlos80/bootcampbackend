using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceApi.Services
{
    public class ProducerRabbit
    {
        private readonly ConnectionFactory _factory;
        private readonly IConnection _connection;        
        private const string UPDATE_ATTENDANCE_QUEUE = "UpdateAttendanceQueue";

        private readonly string USERNAME = "guest";
        private readonly string PASSWORD = "guest";
        private readonly string HOSTNAME = "localhost";
        private readonly int PORT = 5672;

        public ProducerRabbit()
        {
            _factory = new() {                
                HostName = HOSTNAME,
                Port = PORT,
                UserName = USERNAME,
                Password = PASSWORD
            };

            _connection = _factory.CreateConnection();            
        }

        public void NotifyUpdate(int userId, int totalAttendance)
        {
            using (var channel = _connection.CreateModel())
            {
                channel.QueueDeclare(queue: UPDATE_ATTENDANCE_QUEUE,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                
                var body = Encoding.UTF8.GetBytes(
                    JsonConvert.SerializeObject(
                    new { 
                        Id = userId,
                        TotalAttendance = totalAttendance
                    }));
                    
                channel.BasicPublish(exchange: "",
                                     routingKey: UPDATE_ATTENDANCE_QUEUE,
                                     basicProperties: null,
                                     body: body);
            }
        }        
    }
}
