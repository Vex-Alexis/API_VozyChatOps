using API_VozyChatOps.DTOs;
using API_VozyChatOps.Models;
using API_VozyChatOps.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_VozyChatOps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScheduleController : ControllerBase
    {
        private readonly ScheduleService _scheduleService;
        private readonly PDFGenerationService _pDFGenerationService;

        public ScheduleController(ScheduleService scheduleService, PDFGenerationService pDFGenerationService)
        {
            _scheduleService = scheduleService;
            _pDFGenerationService = pDFGenerationService;
        }

        //public async Task<ActionResult<List<ScheduleModel>>> GetSchedulesByNumIdentificacion([FromBody] ScheduleRequestDTO scheduleRequestDTO)

        [Authorize]
        [HttpGet("query/{numIdentificacion}")]
        public async Task<ActionResult<List<ScheduleModel>>> GetSchedulesByNumIdentificacion(string numIdentificacion)
            
        {
            //var numIdentificacion = scheduleRequestDTO.NUM_IDENTIFICACION;

            if (numIdentificacion == null)
            {
                return BadRequest(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = "Número de identificación no válido." });
            }

            var schedules = await _scheduleService.GetSchedulesByNumIdentificacionAsync(numIdentificacion);

            if (schedules == null || schedules.Count == 0)
            {
                return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = $"No se encontro horario para el estudiante: {numIdentificacion}" });
            }
            return Ok(new { Status = true, Code = HttpStatusCode.OK, Message = "Horario generado con exito", schedules });
            
        }

        [Authorize]
        [HttpPost("generate-pdf")]
        public async Task<ActionResult<List<ScheduleModel>>> GetPDFSchedulesByNumIdentificacion([FromBody] ScheduleRequestDTO scheduleRequestDTO)
        {
            try
            {
                if (!ModelState.IsValid || string.IsNullOrEmpty(scheduleRequestDTO.NUM_IDENTIFICACION))
                {
                    return BadRequest(new { Status = false, Code = HttpStatusCode.BadRequest, Message = "Número de identificación no válido o vacio." });
                }

                var numIdentificacion = scheduleRequestDTO.NUM_IDENTIFICACION;

                // Generar el PDF
                var pdfBase64 = await _pDFGenerationService.GeneratePdfAsync(numIdentificacion);

                if (pdfBase64 == null)
                {
                    // Si el estudiante no existe o no tiene horario asignado, responder con un mensaje adecuado
                    return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Message = "Estudiante no encontrado o no tiene horario asignado." });
                }

                // Retornar la respuesta exitosa con el PDF
                return Ok(new { Status = true, Code = HttpStatusCode.OK, Message = "Horario generado con éxito", PdfBase64 = pdfBase64 });
            }
            catch (Exception ex)
            {
                // Manejar otras excepciones
                return StatusCode(500, new { Status = false, Code = HttpStatusCode.InternalServerError, Message = $"Error interno del servidor: {ex.Message}" });
            }
        }


    }
}
