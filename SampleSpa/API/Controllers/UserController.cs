using API.Data;
using API.Model.DTOs;
using API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SPA.Services;

namespace SPA.Controllers
{

    [ApiController]
    [Route("api/[controller][action]")]

    public class UserController : Controller
    {
        private readonly IUser _userService;

        public UserController(IUser userService)
        {
            _userService = userService;
        }


        [HttpPost]
        public async Task<IActionResult> SaveUser([FromBody] IList<UserDto> users)
        {

            return Ok(await _userService.CreateUsers(users));
        }



        [HttpGet]
        [Authorize(Roles = "admin")]
        public async Task<IActionResult> GetAllUsers()
        {
            
            return Ok(await _userService.GetAllUsers());
        }



    }
}
