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
            // Asegúrate de validar y procesar la solicitud según tus requisitos antes de realizar la llamada al servicio
            // Por ejemplo, podrías validar el modelo (ModelState.IsValid) y manejar errores.

            var response = await _resetPasswordService.ResetPasswordAsync(resetPasswordRequestDTO.Email);

            return Ok(new { Status = true, Code = HttpStatusCode.OK, Message = response });
        }

    }
}
