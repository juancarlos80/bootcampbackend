using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using UserAPI.DTO;
using UserAPI.Models;
using UserAPI.Security;
using UserAPI.Services;

namespace UserAPI.Controllers
{
    [Route("users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserContext context;        
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly IJsonWebToken jwtToken;

        public UserController(
            UserContext context,
            IConfiguration configuration,
            IJsonWebToken jwtToken,
            IMapper mapper)
        {
            this.context = context;
            this.configuration = configuration;
            this.mapper = mapper;
            this.jwtToken = jwtToken;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserList>>> GetUsers()
        {
            return await context
                .Users
                .Select(u => new UserList 
                    { 
                        Id = u.Id, 
                        NickName = u.NickName, 
                        TotalAttendance = u.TotalAttendance } )
                .ToListAsync();
        }

        [HttpGet("/users/search")]
        public async Task<ActionResult<IEnumerable<UserList>>> GetUsers(string text)
        {
            return await context
                .Users
                .Where(u => 
                    u.NickName.ToLower().Contains(text.ToLower()) || 
                    u.Name.ToLower().Contains(text.ToLower()) 
                )
                .Select(u => new UserList
                {
                    Id = u.Id,
                    NickName = u.NickName,
                    TotalAttendance = u.TotalAttendance
                })                
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetail>> GetUser(int id)
        {
            var user = await context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            UserDetail userDetail = mapper.Map<UserDetail>(user);
            
            userDetail.Attendances = new AttendanceService()
                .getAttendances(user.Id);

            return userDetail;
        }
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            context.Entry(user).State = EntityState.Modified;

            try
            {
                await context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPut("{id}/attendance")]
        public async Task<IActionResult> PutUserAttendance(int id, UserAttendanceUpdate userAttendance)
        {
            if (id != userAttendance.Id)
            {
                return BadRequest();
            }

            User user = await context.Users.FindAsync(id);
            if ( user is not null )
            {

                user.TotalAttendance = userAttendance.TotalAttendance;
                context.Entry(user).State = EntityState.Modified;

                try
                {
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
            }

            return NoContent();
        }
        
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(UserCreate userCreate)
        {            
            User user = this.mapper.Map<User>(userCreate);

            user.CreatedAt = DateTime.Now;
            context.Users.Add(user);
            await context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            context.Users.Remove(user);
            await context.SaveChangesAsync();
            
            ProducerRabbit producer = new ProducerRabbit();
            producer.NotifyUserDeleted(id);

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return context.Users.Any(e => e.Id == id);
        }

        [HttpPost("login")]
        public async Task<ActionResult<string>> Login(UserLogin userLogin)
        {            
            User userAuthentication = context
                .Users
                .Where( usr => 
                    usr.Email.Equals(userLogin.Email) &&
                    usr.Password.Equals(userLogin.Password))
                .First();

            if (userAuthentication is not null)
            {
                return this.jwtToken.SignToken(userAuthentication, this.configuration);
            }

            return this.BadRequest();
        }

        /*[HttpGet("login")]
        [Authorize]
        public ActionResult<IEnumerable<string>> Get()
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
