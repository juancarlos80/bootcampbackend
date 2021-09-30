using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserAPI.Models;

namespace UserAPI.DTO
{
    public class MapperUser : Profile
    {
        public MapperUser()
        {
            this.CreateMap<User, UserDetail>();
            this.CreateMap<UserCreate, User>();
            this.CreateMap<UserLogin, User>();
            this.CreateMap<UserAttendanceUpdate, User>();
        }
    }
}
