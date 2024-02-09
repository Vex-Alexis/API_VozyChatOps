using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace API_VozyChatOps.DTOs
{
    public class EstudianteActivoResponseDTO
    {
        [JsonPropertyName("NumeroIdentificacion")]
        public string NUM_IDENTIFICACION { get; set; }
        [JsonPropertyName("PrimerNombre")]
        public string NOM_TERCERO { get; set; }
        [JsonPropertyName("SegundoNombre")]
        public string SEG_NOMBRE { get; set; }
        [JsonPropertyName("PrimerApellido")]
        public string PRI_APELLIDO { get; set; }
        [JsonPropertyName("SegundoApellido")]
        public string SEG_APELLIDO { get; set; }

        [JsonPropertyName("EmailPersonal")]
        public string DIR_EMAIL_PER { get; set; }
        [JsonPropertyName("EmailInstitucional")]
        public string DIR_EMAIL { get; set; }
        [JsonPropertyName("EstadoAlumno")]
        public string ESTADO_ALUMNO { get; set; }

    }
}
