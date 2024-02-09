using API_VozyChatOps.DTOs;
using API_VozyChatOps.Models;
using API_VozyChatOps.Repositories.Implementations;
using API_VozyChatOps.Repositories.Interfaces;

namespace API_VozyChatOps.Services
{
    public class EstadisticaEstudiantesService
    {
        private readonly IEstadisticaEstudianteRepository _estadisticaEstudianteRepository;

        public EstadisticaEstudiantesService(IEstadisticaEstudianteRepository estadisticaEstudianteRepository)
        {
            _estadisticaEstudianteRepository = estadisticaEstudianteRepository;
        }

        public async Task<EstudianteActivoResponseDTO> ObtenerEstudiantesActivosPorIdentificacion(EstudianteActivoRequestDTO estudianteActivoRequestDTO)
        {

            EstudianteActivoResponseDTO estudiante = await _estadisticaEstudianteRepository.ObtenerEstudiantesActivosPorIdentificacion(estudianteActivoRequestDTO);

            return estudiante;
        }



        public int ObtenerCantidadEstudiantesActivos()
        {
            //return _estadisticaEstudianteRepository.ObtenerCantidadEstudiantesActivos();

            return _estadisticaEstudianteRepository.ObtenerCantidadEstudiantesActivosConADO();
        }


    }
}
