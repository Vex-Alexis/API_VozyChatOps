using System.ComponentModel.DataAnnotations.Schema;

namespace API_VozyChatOps.Models
{
    [Table("MATRIZ_CALENDARIO", Schema = "CUN")]
    public class MatrizCalendarioModel
    {
        //public DateTime FI_CONV { get; set; }
        //public DateTime FF_CONV { get; set; }
        public string PERIODO { get; set; }
        public string MODALIDAD { get; set; }
        public string FI_CLASE { get; set; }
        public string FF_CLASE { get; set; }
        //public string AÑO { get; set; }
    }


}
