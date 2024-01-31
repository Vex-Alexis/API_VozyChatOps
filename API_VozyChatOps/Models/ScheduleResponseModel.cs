namespace API_VozyChatOps.Models
{
    public class ScheduleResponseModel
    {
        public bool status { get; set; }
        public int code { get; set; }
        public string message { get; set; }
        public List<ScheduleModel> schedules { get; set; }
    }
}
