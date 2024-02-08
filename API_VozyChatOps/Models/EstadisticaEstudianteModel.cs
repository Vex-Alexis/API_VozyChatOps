using System.ComponentModel.DataAnnotations.Schema;

namespace API_VozyChatOps.Models
{
    [Table("ESTADISTICA_ESTUDIANTE_2", Schema = "CUN")]
    public class EstadisticaEstudianteModel
    {
        public string COD_PERIODO { get; set; }
        public string NOM_TERCERO { get; set; }
        public string SEG_NOMBRE { get; set; }
        public string PRI_APELLIDO { get; set; }
        public string SEG_APELLIDO { get; set; }
        public string NUM_IDENTIFICACION { get; set; }
        public string GEN_TERCERO { get; set; }
        public string TIP_IDENTIFICACION { get; set; }
        public string DIR_EMAIL_PER { get; set; }
        public string DIR_EMAIL { get; set; }
        public string TEL_RESIDENCIA { get; set; }
        public string TEL_CELULAR { get; set; }
        public string COD_UNIDAD { get; set; }
        public string NOM_UNIDAD { get; set; }
        public string COD_PENSUM { get; set; }
        public string COD_PENSUM_LAURA { get; set; }
        public string NOM_DEPENDENCIA { get; set; }
        public string MUNICIPIO_RESIDENCIA { get; set; }
        public string DEPARTAMENTO_RESIDENCIA { get; set; }
        public string MUNICIPIO_SEDE { get; set; }
        public string DEPARTAMENTO_SEDE { get; set; }
        //public DateTime FEC_NACIMIENTO { get; set; }
        public string EDAD { get; set; }
        public string MODALIDAD { get; set; }
        public string NIVEL_FORMACION { get; set; }
        public string NOM_SECCIONAL { get; set; }
        public string COD_DPTO { get; set; }
        public string CICLO { get; set; }
        public string ubicacion { get; set; }
        public string CLASE_ACTUAL { get; set; }
        public string NUEVO { get; set; }
        public string ESTADO_ALUMNO { get; set; }
        //public string ESTADO_PAGO { get; set; }
        //public string UNIDADNEGOCIO { get; set; }
        //public string SEMESTRE { get; set; }
        //public string NOM_SEDE { get; set; }
        //public string ESTADO_MOODLE { get; set; }
        //public DateTime ultimo_acceso_moodle { get; set; }
        //public string AÑO { get; set; }
        //public string SEMESTRE_CALCULADO { get; set; }
        //public string NOMBRE_ESCUELA { get; set; }
        //public string Estrato { get; set; }
        //public decimal promedio { get; set; }
        //public decimal PRO_ACUMULADO { get; set; }

    }
}
