using System.Net.Http.Headers;
using API_VozyChatOps.DTOs;

namespace API_VozyChatOps.Services
{
    public class ResetPasswordService
    {
        private readonly HttpClient _httpClient;

        public ResetPasswordService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        public async Task<string> ResetPasswordAsync(string email)
        {

            string endpointUrl = $"https://newmail.cunapp.pro/api/Users/ResetPassword?email={Uri.EscapeDataString(email)}";
            string username = "CreadorCorreosCUN";
            string password = "CUNDigital2023!@$#";

            try
            {
                var byteArray = System.Text.Encoding.ASCII.GetBytes($"{username}:{password}");
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));

                var response = await _httpClient.GetAsync(endpointUrl);

                if (response.IsSuccessStatusCode)
                {
                    // Aquí puedes procesar la respuesta si es necesario
                    return "Solicitud de restablecimiento de contraseña realizada con éxito.";
                }
                else
                {
                    // Manejar el caso en que la solicitud no sea exitosa
                    return $"Error en la solicitud: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                // Manejar excepciones si ocurren durante la solicitud
                return $"Error en la solicitud: {ex.Message}";
            }

        }

    }
}
