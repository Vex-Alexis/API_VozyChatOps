using API_VozyChatOps.Models;
using API_VozyChatOps.Repositories.Interfaces;

namespace API_VozyChatOps.Services
{
    public class ScheduleService
    {
        private readonly IScheduleRepository _scheduleRepository;

        public ScheduleService(IScheduleRepository scheduleRepository)
        {
            _scheduleRepository = scheduleRepository;
        }

        public async Task<List<ScheduleModel>> GetSchedulesByNumIdentificacionAsync(string numIdentificacion)
        {
            return await _scheduleRepository.GetByNumIdentificacionAsync(numIdentificacion);
        }

    }
}
