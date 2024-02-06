using API_VozyChatOps.Security.DTOs;

namespace API_VozyChatOps.Security.Repositories
{
    public class AuthRepository
    {
        public LoginUserDTO GetUser(LoginUserDTO loginUserDTO)
        {
            LoginUserDTO userDTO = new LoginUserDTO
            {
                Username = "ApiVozyChatOps",
                Password = "CUN-ApiVozy2024!@$#"
            };

            return userDTO;
        }

    }

}
