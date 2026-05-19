using LibraryManagementApi.Models;
using LibraryManagementApi.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id}")]
        public ActionResult<UserResponse> GetById(int id)
        {
            var user = _userService.GetUserById(id);
            if (user == null) return NotFound();
            return Ok(ToResponse(user));
        }

        [HttpPost("register")]
        public IActionResult Register(RegisterUserRequest request)
        {
            var user = new User
            {
                Username = request.Username,
                Email = request.Email,
                Role = request.Role,
                Password = request.Password
            };

            _userService.RegisterUser(user);
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public ActionResult<UserResponse> Login([FromBody] LoginRequest request)
        {
            var user = _userService.Login(request.Email, request.Password);
            if (user == null) return Unauthorized("Invalid email or password.");
            return Ok(ToResponse(user));
        }

        private static UserResponse ToResponse(User user)
        {
            return new UserResponse
            {
                UserId = user.UserID,
                Username = user.Username,
                Email = user.Email,
                Role = user.Role,
                CreatedAt = user.CreatedAt,
                UpdatedAt = user.UpdatedAt,
                IsDeleted = user.IsDeleted
            };
        }
    }

    public class RegisterUserRequest
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class UserResponse
    {
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public bool IsDeleted { get; set; }
    }
}