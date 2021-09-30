using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApi.Models
{
    public class AttendanceDatabaseSettings : IAttendanceDatabaseSettings
    {
        public string AttendanceCollectionName { get ; set; }
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
