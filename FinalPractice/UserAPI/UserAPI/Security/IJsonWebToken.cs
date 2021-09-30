using Microsoft.Extensions.Configuration;
using UserAPI.Models;

namespace UserAPI.Security
{
    public interface IJsonWebToken
    {
        public string SignToken(User user, IConfiguration configuration);
    }
}
