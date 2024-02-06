using API_VozyChatOps.Security.DTOs;
using API_VozyChatOps.Security.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;


namespace API_VozyChatOps.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }


        [HttpPost("login")]
        public IActionResult Login(LoginUserDTO loginUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(new { Status = false, Message = "Invalid model state", Errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            // Autenticar al usuario
            var (isAuthenticated, token) = _authService.AuthenticateUser(loginUserDTO);

            if (isAuthenticated)
            {
                return Ok(new { Status = true, Message = "Authentication successful", Token = token });
            }

            return Unauthorized(new { Status = false, Message = "Invalid credentials" });
        }
    }
}
