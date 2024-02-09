using API_VozyChatOps.DTOs;
using API_VozyChatOps.Models;

namespace API_VozyChatOps.Repositories.Interfaces
{
    public interface IEstadisticaEstudianteRepository
    {
        public Task<EstudianteActivoResponseDTO> ObtenerEstudiantesActivosPorIdentificacion(EstudianteActivoRequestDTO estudianteActivoRequestDTO);

        //public int ObtenerCantidadEstudiantesActivos();

        public int ObtenerCantidadEstudiantesActivosConADO();

    }
}
