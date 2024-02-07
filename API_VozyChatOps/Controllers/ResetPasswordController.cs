using API_VozyChatOps.DTOs;
using API_VozyChatOps.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_VozyChatOps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResetPasswordController : ControllerBase
    {
        private readonly ResetPasswordService _resetPasswordService;

        public ResetPasswordController(ResetPasswordService resetPasswordService)
        {
            _resetPasswordService = resetPasswordService;
        }

        [Authorize]
        [HttpPost("email")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordRequestDTO resetPasswordRequestDTO)
        {
            if (!ModelState.IsValid)
            {
                // Manejar el caso en que el modelo no sea válido
                return BadRequest(new { Status = false, Code = HttpStatusCode.BadRequest, Message = "Modelo de datos no válido", Errors = ModelState.Values.SelectMany(v => v.Errors) });
            }

            try
            {

                var response = await _resetPasswordService.ResetPasswordAsync(resetPasswordRequestDTO.Email);

                if (response.Contains("Restablecimiento de contraseña realizada con éxito"))
                {
                    // El restablecimiento de contraseña fue exitoso
                    return Ok(new { Status = true, Code = HttpStatusCode.OK, Message = response });
                }
                else
                {
                    // Manejar el caso en que la solicitud no sea exitosa
                    return BadRequest(new { Status = false, Code = HttpStatusCode.BadRequest, Message = response });
                }
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones
                return StatusCode(500, new { Status = false, Code = HttpStatusCode.InternalServerError, Message = $"Error interno del servidor: {ex.Message}" });
            }
        }

    }
}
