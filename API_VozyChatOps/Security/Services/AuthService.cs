using API_VozyChatOps.Security.DTOs;
using API_VozyChatOps.Security.Repositories;

using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace API_VozyChatOps.Security.Services
{
    public class AuthService
    {
        private readonly AuthRepository _authRepository;
        private IConfiguration _config;

        public AuthService(AuthRepository authRepository, IConfiguration config)
        {
            _authRepository = authRepository;
            _config = config;
        }


        public (bool isAuthenticated, string token) AuthenticateUser(LoginUserDTO loginUserDTO)
        {
            LoginUserDTO storedUser = _authRepository.GetUser(loginUserDTO);

            // Verificar si las credenciales coinciden
            bool isAuthenticated = AreCredentialsValid(loginUserDTO, storedUser);

            // Si las credenciales son válidas, generamos el token
            string token = isAuthenticated ? GenerateToken(storedUser) : string.Empty;

            return (isAuthenticated, token);
        }

        private bool AreCredentialsValid(LoginUserDTO providedUser, LoginUserDTO storedUser)
        {
            // Verificar si el nombre de usuario y la contraseña coinciden
            return storedUser != null &&
                   storedUser.Username == providedUser.Username &&
                   storedUser.Password == providedUser.Password;
        }

        private string GenerateToken(LoginUserDTO user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Username)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var securityToken = new JwtSecurityToken(
                claims: claims,
                //expires: null,
                expires: DateTime.Now.AddHours(12),
                signingCredentials: credentials
                );

            string token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            return token;
        }


    }
}
