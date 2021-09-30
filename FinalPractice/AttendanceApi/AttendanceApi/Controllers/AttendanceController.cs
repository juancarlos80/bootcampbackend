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
        private readonly AttendanceService attendanceService;

        public AttendanceController(AttendanceService attendanceService)
        {
            this.attendanceService = attendanceService;

        }

        [HttpGet]
        public ActionResult<List<Attendance>> Get() =>
            attendanceService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAttendance")]
        public ActionResult<Attendance> Get(string id)
        {
            var attendance = attendanceService.Get(id);

            if (attendance == null)
            {
                return NotFound();
            }

            return attendance;
        }

        [HttpGet("user/{id}")]
        public ActionResult<List<Attendance>> GetUserAttendances(int id)
        {
            var attendance = attendanceService.GetUserAttendances(id);

            if (attendance == null)
            {
                return NotFound();
            }

            return attendance;
        }

        [HttpPost]
        public ActionResult<Attendance> Create(Attendance attendance)
        {
            attendanceService.Create(attendance);
            
            UpdateAttendances(attendance.UserId);

            return CreatedAtRoute(
                "GetAttendance", 
                new { id = attendance.Id.ToString() }, 
                attendance);
        }        

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Attendance attendanceIn)
        {
            var attendance = attendanceService.Get(id);

            if (attendance == null)
            {
                return NotFound();
            }

            attendanceService.Update(id, attendanceIn);

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
                userId = Int32.Parse(
                    currentUser
                    .Claims
                    .FirstOrDefault(c => c.Type == "id")
                    .Value);
            }

            if (userId == 0 ) {
                return NotFound("Without Authorize");
            }

            var attendance = attendanceService.Get(id);

            if (attendance == null)
            {
                return NotFound();
            }            

            if ( attendance.UserId != userId )
            {
                return NotFound("Without Authorize");
            }

            attendanceService.Remove(attendance.Id);
            
            UpdateAttendances(userId);

            return NoContent();
        }

        [HttpDelete("user/{userId}")]
        public IActionResult DeleteAllUser(int userId)
        {
            attendanceService.RemoveUserId(userId);
            return NoContent();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        public void UpdateAttendances(int userId)
        {
            var total_attendance = attendanceService
                .GetUserAttendances(userId)
                .Count();

            ProducerRabbit producer = new ProducerRabbit();
            producer.NotifyUpdate(userId, total_attendance);
        }        
    }
}
