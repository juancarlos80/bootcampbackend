using AttendanceApi.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApi.Services
{
    public class AttendanceService
    {
        private readonly IMongoCollection<Attendance> _attendances;

        public AttendanceService(IAttendanceDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _attendances = database
                .GetCollection<Attendance>(
                    settings.AttendanceCollectionName);
        }

        public List<Attendance> Get() =>
            _attendances.Find(book => true).ToList();

        public List<Attendance> GetUserAttendances(int userId) =>
            _attendances.Find(att => att.UserId == userId).ToList();

        public Attendance Get(string id) =>
            _attendances.Find<Attendance>(att => att.Id == id).FirstOrDefault();

        public Attendance Create(Attendance attendance)
        {
            _attendances.InsertOne(attendance);
            return attendance;
        }

        public void Update(string id, Attendance attendanceIn) =>
            _attendances.ReplaceOne(att => att.Id == id, attendanceIn);

        public void Remove(Attendance attendance) =>
            _attendances.DeleteOne(att => att.Id == attendance.Id);

        public void Remove(string id) =>
            _attendances.DeleteOne(att => att.Id == id);

        public void RemoveUserId(int userId) =>
            _attendances.DeleteMany(att => att.UserId == userId);
    }
}
