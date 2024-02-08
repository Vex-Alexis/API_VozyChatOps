using API_VozyChatOps.Models;

namespace API_VozyChatOps.Repositories.Interfaces
{
    public interface IEstadisticaEstudianteRepository
    {
        Task<EstadisticaEstudianteModel> GetEstadisticaEstudiante(string numIdentificacion);

        //public int ObtenerCantidadEstudiantesActivos();

        public int ObtenerCantidadEstudiantesActivosConADO();

    }
}
