using API.Data;
using API.Model.Domain;
using API.Model.DTOs;
using API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SPA.Services
{
    public class UserService : IUser
    {

        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserDto>> GetAllUsers()
        {

            var users = await _context.User.ToListAsync();
            var userDto = new List<UserDto>();

            foreach (var user in users)
            {

               userDto.Add( new UserDto { UserName = user.UserName, Password = user.Password });
            }

            return userDto;

        }


        public async Task<List<UserDto>> CreateUsers(IList<UserDto> users)
        {
            foreach(var user in users) {

                _context.User.Add(new User { UserName = user.UserName, Password = user.Password, Roles = "admin"  });
            }

            _context.SaveChanges();


            return await GetAllUsers();


        }

        public async Task<UserDto> AuthenticateAsync(string username, string password)
        {
            var user =  _context.User.Where(x => x.UserName == username && x.Password == password).FirstOrDefault();

            return new UserDto { UserName = user.UserName, Password = user.Password, Roles = user.Roles };
        }
    }
}

