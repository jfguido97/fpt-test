using API.Data;
using API.Model.DTOs;
using API.Services.Interfaces;
using System.Text;

namespace API.Services
{
    public class AuthService : IAuth
    {

        private readonly DataContext _context;
        public AuthService(DataContext context)
        {
            _context = context;
        }

        public Task<UserDto> Login(UserDto login)
        {
            throw new NotImplementedException();
        }


    }
}
