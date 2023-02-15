using API.Model.Domain;
using API.Model.DTOs;

namespace API.Services.Interfaces
{
    public interface IUser
    {
        public Task<List<UserDto>> GetAllUsers();
        public Task<List<UserDto>> CreateUsers(IList<UserDto> users);
        Task<UserDto> AuthenticateAsync(string username, string password);

    }
}
