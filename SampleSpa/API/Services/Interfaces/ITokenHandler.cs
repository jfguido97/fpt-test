using API.Model.Domain;
using API.Model.DTOs;

namespace API.Services
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(UserDto user);
    }
}
