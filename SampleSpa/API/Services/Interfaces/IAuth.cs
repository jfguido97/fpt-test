using API.Model.DTOs;

namespace API.Services.Interfaces
{
    public interface IAuth
    {
        public Task<UserDto> Login(UserDto login);
    }
}
