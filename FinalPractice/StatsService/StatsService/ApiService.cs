using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace StatsService
{
    class ApiService
    {
        private const string URL_ATTENDANCE = "https://localhost:5011/attendances/";
        private const string URL_USER = "https://localhost:5001/users/";

        public static bool DeleteAttendances(string strId) {
            Console.WriteLine("Delete user: " + strId);
            try
            {
                int userId = Int32.Parse(strId);
                var wb = new WebClient();
                string url = URL_ATTENDANCE+"user/" + userId;
                wb.UploadValues(url, "DELETE", new NameValueCollection());
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public static bool UpdateAttendance(string message)
        {
            Console.WriteLine("Update Attendances: " + message);
            JObject json_response = JObject.Parse(message);
            try
            {                
                HttpWebRequest request = WebRequest.CreateHttp(
                    URL_USER + 
                    json_response.GetValue("Id") + 
                    " /attendance");

                request.Method = "PUT";
                request.AllowWriteStreamBuffering = false;
                request.ContentType = "application/json";
                request.Accept = "Accept=application/json";
                request.SendChunked = false;
                request.ContentLength = message.Length;
                using (var writer = new StreamWriter(request.GetRequestStream()))
                {
                    writer.Write(message);
                }
                var response = request.GetResponse() as HttpWebResponse;

                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

    }
}
