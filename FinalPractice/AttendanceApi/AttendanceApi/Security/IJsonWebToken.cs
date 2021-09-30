using Microsoft.Extensions.Configuration;

namespace AttendanceApi.Security
{
    public interface IJsonWebToken
    {
        public string SignToken( IConfiguration configuration);
    }
}
