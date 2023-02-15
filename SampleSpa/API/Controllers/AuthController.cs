using Microsoft.AspNetCore.Mvc;
using API.Model.DTOs;
using API.Services;
using API.Services.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller][action]")]

    public class AuthController : Controller
    {

        private readonly IUser _userRepository;
        private readonly ITokenHandler _tokenHandler;
        public AuthController(IUser userRepository, ITokenHandler tokenHandler)
        {
            _userRepository = userRepository;
            _tokenHandler = tokenHandler;
        }
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> LoginAsync(UserDto loginRequest)
        {
            //validate the incoming request -> hacerlo como tarea -> fue resuelta con FluentValidation


            //check if user is authenticated
            //check username and password
            var user = await _userRepository.AuthenticateAsync(loginRequest.UserName, loginRequest.Password);

            if (user != null)
            {
                //generate a JWT Token
                var token = await _tokenHandler.CreateTokenAsync(user);
                return Ok(token);
            }

            return BadRequest("Username or Password is incorrect");
        }
    }
}
