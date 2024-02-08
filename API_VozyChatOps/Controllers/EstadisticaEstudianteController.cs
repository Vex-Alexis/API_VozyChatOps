using API_VozyChatOps.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace API_VozyChatOps.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadisticaEstudianteController : ControllerBase
    {
        private readonly EstadisticaEstudiantesService _estadisticaEstudiantesService;

        public EstadisticaEstudianteController(EstadisticaEstudiantesService estadisticaEstudiantesService)
        {
            _estadisticaEstudiantesService = estadisticaEstudiantesService;
        }

        [HttpGet("cantidad-activos")]
        public ActionResult<int> ObtenerCantidadEstudiantesActivos()
        {
            var cantidadEstudiantesActivos = _estadisticaEstudiantesService.ObtenerCantidadEstudiantesActivos();

            return Ok(new { Status = true, Code = HttpStatusCode.OK, Message = "Cantidad de estudiantes activos generada exitosamente", EstudiantesActivos = cantidadEstudiantesActivos });
        }




    }
}
