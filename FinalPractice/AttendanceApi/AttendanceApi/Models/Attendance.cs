using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApi.Models
{
    public class Attendance
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string InitTime { get; set; }
        public string EndTime { get; set; }
        public string Date { get; set; }
        public string Notes { get; set; }
        public int UserId { get; set; }
    }
}
