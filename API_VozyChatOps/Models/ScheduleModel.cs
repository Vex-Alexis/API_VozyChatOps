using System.ComponentModel.DataAnnotations.Schema;

namespace API_VozyChatOps.Models
{
    [Table("Horarios", Schema = "CUN")]
    public class ScheduleModel
    {
        public string? NUM_IDENTIFICACION { get; set; }
        public string? NOM_LARGO { get; set; }
        public string? COD_UNIDAD { get; set; }
        public string? NOM_UNIDAD { get; set; }
        public string? COD_PENSUM { get; set; }
        public string? COD_MATERIA { get; set; }
        public string? NOM_MATERIA { get; set; }
        public string? DOC_DOCENTE { get; set; }
        public string? NOM_DOCENTE { get; set; }
        public DateTime? FEC_INI_PROGRAMACION { get; set; }
        public DateTime? FEC_FIN_PROGRAMACION { get; set; }
        public string? DIA { get; set; }
        public string? HORA_INICIAL { get; set; }
        public string? HORA_FINAL { get; set; }
        public string? NOM_AULA { get; set; }
    }
}
