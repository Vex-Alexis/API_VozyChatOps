using API_VozyChatOps.DTOs;
using API_VozyChatOps.Models;
using API_VozyChatOps.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_VozyChatOps.Controllers
{
    [Authorize]
    [Route("api")]
    [ApiController]
    public class EstadisticaEstudianteController : ControllerBase
    {
        private readonly EstadisticaEstudiantesService _estadisticaEstudiantesService;

        public EstadisticaEstudianteController(EstadisticaEstudiantesService estadisticaEstudiantesService)
        {
            _estadisticaEstudiantesService = estadisticaEstudiantesService;
        }

        [HttpPost("estudianteActivo")]
        public async Task<ActionResult<EstudianteActivoResponseDTO>> ObtenerEstudianteActivoPorIdentificacion([FromBody] EstudianteActivoRequestDTO estudianteActivoRequestDTO)
        {
            try
            {
                var estudiante = await _estadisticaEstudiantesService.ObtenerEstudiantesActivosPorIdentificacion(estudianteActivoRequestDTO);

                if (estudiante == null)
                {
                    return NotFound(new { Status = false, Code = HttpStatusCode.NotFound, Messagge = "No se encontró al estudiante o no se encuentra activo en el período actual." });
                }

                return Ok(new { Status = true, Code = HttpStatusCode.OK, Message = "Estudiante encontrado exitosamente", Estudiante = estudiante });
            }
            catch (Exception ex)
            {
                // Manejo de errores, puedes registrar el error, devolver un código de estado específico, etc.
                return StatusCode(500, $"Error interno del servidor: {ex.Message}");
            }
        }


        [HttpGet("cantidad-activos")]
        public ActionResult<int> ObtenerCantidadEstudiantesActivos()
        {
            var cantidadEstudiantesActivos = _estadisticaEstudiantesService.ObtenerCantidadEstudiantesActivos();

            return Ok(new { Status = true, Code = HttpStatusCode.OK, Message = "Cantidad de estudiantes activos generada exitosamente", EstudiantesActivos = cantidadEstudiantesActivos });
        }




    }
}
