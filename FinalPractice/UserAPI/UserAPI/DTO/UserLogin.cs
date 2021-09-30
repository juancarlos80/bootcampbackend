using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserAPI.DTO
{
    public class UserLogin
    {
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
