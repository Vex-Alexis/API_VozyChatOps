using System.Reflection.Metadata;
using System.Text;


namespace API_VozyChatOps.Services
{
    public class PDFGenerationService
    {
        private readonly ScheduleService _scheduleService;

        public PDFGenerationService(ScheduleService scheduleService)
        {
            _scheduleService = scheduleService;
        }

        public async Task<byte[]> GeneratePdfAsync(string numIdentificacion)
        {
            var schedules = await _scheduleService.GetSchedulesByNumIdentificacionAsync(numIdentificacion);

           
            return null;
        }
    }
}
