using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProiectASPNET.Helpers.Attributes;
using ProiectASPNET.Models.DTOs;
using ProiectASPNET.Models.enums;
using ProiectASPNET.Models;
using ProiectASPNET.Services.UserService;
using BCryptNet = BCrypt.Net.BCrypt;
using Microsoft.EntityFrameworkCore;
using ProiectASPNET.Data;
using System.Security.Claims;
using System.Net.Http;
using Microsoft.Extensions.Primitives;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using System.IdentityModel.Tokens.Jwt;

namespace ProiectASPNET.Controllers.Users
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ProjectContext _context;

        public UsersController(IUserService userService, ProjectContext context)
        {
            _userService = userService;
            _context = context;
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(UserRequestDTO user)
        {
            var userToCreate = new User
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = Role.User,
                Email = user.Email,
                PasswordHash = BCryptNet.HashPassword(user.Password)
            };
            if (await _context.Users.AnyAsync(x => x.UserName == userToCreate.UserName))
            {
                return BadRequest("User with the same username already exists");
            }
            await _userService.Create(userToCreate);
            return Ok();
        }

        [HttpPost("create-admin")]
        public async Task<IActionResult> CreateAdmin(UserRequestDTO user)
        {
            var userToCreate = new User
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Role = Role.Admin,
                Email = user.Email,
                PasswordHash = BCryptNet.HashPassword(user.Password)
            };
            await _userService.Create(userToCreate);
            return Ok();
        }

        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(UserRequestDTO user)
        {
            var response = _userService.Authenticate(user);
            if (response == null)
            {
                return BadRequest("Username or password is invalid!");
            }
            return Ok(new { Token = response.Token });
        }

        [Authorization(Role.Admin)]
        [HttpGet("admin")]
        public IActionResult GetAllAdmin()
        {
            var users = _userService.GetAllUsers();
            return Ok(users);
        }

        [Authorization(Role.User)]
        [HttpGet("user")]
        public IActionResult GetAllUser()
        {
            return Ok("User");
        }
    }
}