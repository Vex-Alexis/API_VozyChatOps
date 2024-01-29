using API_VozyChatOps.Models;

namespace API_VozyChatOps.Repositories.Interfaces
{
    public interface IScheduleRepository
    {
        Task<List<ScheduleModel>> GetByNumIdentificacionAsync(string numIdentificacion);

    }
}
