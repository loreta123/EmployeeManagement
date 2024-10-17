using EmployeeManagementWebApi.Models;
using EmployeeManagementWebApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IJwtTokenService _jwtTokenService;

        public AuthController(IJwtTokenService jwtTokenService)
        {
            _jwtTokenService = jwtTokenService;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            // Perform authentication 
            var user = AuthenticateUser(model);

            if (user == null)
            {
                return Unauthorized(); // Return 401 if authentication fails
            }

            // Generate JWT using the JwtTokenService
            var token = _jwtTokenService.GenerateToken(user.Id, user.Role);

            // Return the token in the response
            return Ok(new { token });
        }

        private User AuthenticateUser(LoginModel model)
        {

            if (model.Username == "test" && model.Password == "password")
            {
                return new User { Id = "1", Role = "Admin" }; 
            }

            return null; // Return null if authentication fails
        }
    }
}
