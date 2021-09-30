using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.DTO
{
    public class Attendance
    {
        public string id { get; set; }
        public string initTime { get; set; }
        public string endTime { get; set; }
        public string date { get; set; }
        public string notes { get; set; }
        public int userId { get; set; }
    }
}
