using API_VozyChatOps.Security.DTOs;
using API_VozyChatOps.Security.Repositories;

namespace API_VozyChatOps.Security.Services
{
    public class AuthService
    {
        private readonly AuthRepository _authRepository;

        public AuthService(AuthRepository authRepository)
        {
            _authRepository = authRepository;
        }


        public bool AuthenticateUser(LoginUserDTO loginUserDTO)
        {
            LoginUserDTO storedUser = _authRepository.GetUser(loginUserDTO);

            // Verificar si las credenciales coinciden
            bool isAuthenticated = AreCredentialsValid(loginUserDTO, storedUser);

            return isAuthenticated;
        }

        private bool AreCredentialsValid(LoginUserDTO providedUser, LoginUserDTO storedUser)
        {
            // Verificar si el nombre de usuario y la contraseña coinciden
            return storedUser != null &&
                   storedUser.Username == providedUser.Username &&
                   storedUser.Password == providedUser.Password;
        }


    }
}
