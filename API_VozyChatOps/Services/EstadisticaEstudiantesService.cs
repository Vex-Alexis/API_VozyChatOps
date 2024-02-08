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

        public int ObtenerCantidadEstudiantesActivos()
        {
            //return _estadisticaEstudianteRepository.ObtenerCantidadEstudiantesActivos();

            return _estadisticaEstudianteRepository.ObtenerCantidadEstudiantesActivosConADO();
        }


    }
}
