using AttendanceApi.Models;
using AttendanceApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AttendanceApi.Controllers
{
    [Route("attendances")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly AttendanceService _attendanceService;

        public AttendanceController(AttendanceService attendanceService)
        {
            _attendanceService = attendanceService;

        }

        [HttpGet]
        public ActionResult<List<Attendance>> Get() =>
            _attendanceService.Get();

        [HttpGet("{id:length(24)}", Name = "GetBook")]
        public ActionResult<Attendance> Get(string id)
        {
            var attendance = _attendanceService.Get(id);

            if (attendance == null)
            {
                return NotFound();
            }

            return attendance;
        }

        [HttpGet("user/{id}")]
        public ActionResult<List<Attendance>> GetUserAttendances(int id)
        {
            var attendance = _attendanceService.GetUserAttendances(id);

            if (attendance == null)
            {
                return NotFound();
            }

            return attendance;
        }

        [HttpPost]
        public ActionResult<Attendance> Create(Attendance attendance)
        {
            _attendanceService.Create(attendance);

            //Call to Update the total attendace in user API 
            UpdateAttendances(attendance.UserId);

            return CreatedAtRoute("GetBook", new { id = attendance.Id.ToString() }, attendance);
        }        

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Attendance attendanceIn)
        {
            var attendance = _attendanceService.Get(id);

            if (attendance == null)
            {
                return NotFound();
            }

            _attendanceService.Update(id, attendanceIn);

            return NoContent();
        }

        [Authorize]
        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var currentUser = HttpContext.User;
            int userId = 0;            

            if (currentUser.HasClaim(c => c.Type == "id"))
            {
                userId = Int32.Parse(currentUser.Claims.FirstOrDefault(c => c.Type == "id").Value);
            }

            if (userId == 0 ) {
                return NotFound("Without Authorize");
            }

            var attendance = _attendanceService.Get(id);

            if (attendance == null)
            {
                return NotFound();
            }            

            if ( attendance.UserId != userId )
            {
                return NotFound("Without Authorize");
            }

            _attendanceService.Remove(attendance.Id);
            
            UpdateAttendances(userId);

            return NoContent();
        }

        [HttpDelete("user/{userId}")]
        public IActionResult DeleteAllUser(int userId)
        {
            _attendanceService.RemoveUserId(userId);
            return NoContent();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public void UpdateAttendances(int userId)
        {
            var total_attendance = _attendanceService
                .GetUserAttendances(userId)
                .Count();

            ProducerRabbit producer = new ProducerRabbit();
            producer.NotifyUpdate(userId, total_attendance);
        }

        /*[HttpGet("login")]
        [Authorize]
        public ActionResult<IEnumerable<string>> GetLogin()
        {
            var currentUser = HttpContext.User;
            string id = "";
            string name = "";

            if (currentUser.HasClaim(c => c.Type == "id"))
            {
                id = currentUser.Claims.FirstOrDefault(c => c.Type == "id").Value;
            }
            if (currentUser.HasClaim(c => c.Type == "id"))
            {
                name = currentUser.Claims.FirstOrDefault(c => c.Type == "name").Value;
            }

            return new string[] { id, name };
        }*/
    }
}
