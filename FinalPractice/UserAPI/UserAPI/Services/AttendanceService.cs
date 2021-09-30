using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using UserAPI.DTO;

namespace UserAPI.Services
{
    public class AttendanceService
    {
        private readonly string URL_ATTENDANCE = "https://localhost:5011/attendances/user/";

        public List<Attendance> getAttendances(int userId) {
            List<Attendance> attendances = new();

            try
            {
                var wb = new WebClient();
                var myDataBuffer = wb.DownloadData(URL_ATTENDANCE + userId);
                string attendances_string_json = Encoding.ASCII.GetString(myDataBuffer);
                attendances = JsonConvert.DeserializeObject<List<Attendance>>(attendances_string_json);

            } catch (Exception e) {
                Console.WriteLine(e.Message);
            }

            return attendances;
        }
    }
}
