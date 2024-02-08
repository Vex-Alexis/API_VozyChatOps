using API_VozyChatOps.Data;
using API_VozyChatOps.Models;
using API_VozyChatOps.Repositories.Interfaces;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace API_VozyChatOps.Repositories.Implementations
{
    public class EstadisticaEstudianteRepository : IEstadisticaEstudianteRepository
    {
        private readonly AppDBContext _context;

        public EstadisticaEstudianteRepository(AppDBContext context)
        {
            _context = context;
        }

        public async Task<EstadisticaEstudianteModel> GetEstadisticaEstudiante(string numIdentificacion)
        {
            var fechaActual = DateTime.Now.Date;

            var query = from ee in _context.EstadisticaEstudiantes
                        join mc in _context.MatrizCalendarios
                            on ee.COD_PERIODO equals mc.PERIODO
                        where DateTime.ParseExact(mc.FI_CLASE, "dd/MM/yyyy", CultureInfo.InvariantCulture) < fechaActual
                            && DateTime.ParseExact(mc.FF_CLASE, "dd/MM/yyyy", CultureInfo.InvariantCulture) > fechaActual
                            && ee.ESTADO_ALUMNO == "1-Activo"
                            && ee.NUM_IDENTIFICACION == numIdentificacion
                        select new EstadisticaEstudianteModel
                        {
                            // Mapear las propiedades que deseas devolver en el modelo
                            NUM_IDENTIFICACION = ee.NUM_IDENTIFICACION,
                            // Otras propiedades...
                        };

            var student = await query.FirstOrDefaultAsync();
            return student;
        }


        //public int ObtenerCantidadEstudiantesActivos()
        //{
        //    var fechaActual = DateTime.Now.Date;

        //    var cantidadEstudiantesActivos = _context.EstadisticaEstudiantes
        //        .Join(
        //            _context.MatrizCalendarios
        //                .Where(mc => mc.FI_CLASE < fechaActual && mc.FF_CLASE > fechaActual),
        //            ee => ee.COD_PERIODO,
        //            mc => mc.PERIODO,
        //            (ee, mc) => new
        //            {
        //                ee.NUM_IDENTIFICACION,
        //                ee.ESTADO_ALUMNO,
        //                // Otros campos que necesitas utilizar...
        //            }
        //        )
        //        .Count(ee => ee.ESTADO_ALUMNO == "1-Activo");

        //    return cantidadEstudiantesActivos;
        //}


        public int ObtenerCantidadEstudiantesActivosConADO()
        {
            var fechaActual = DateTime.Now.Date;
            var cantidadEstudiantesActivos = 0;

            // Cadena de conexión a tu base de datos
            string connectionString = "Server=172.16.1.33;Database=CUN_REPOSITORIO;User=vozy_chat_api;Password=4n4lyt1cs2024*;Encrypt=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT COUNT(*) AS CantidadRegistros
                    FROM CUN.ESTADISTICA_ESTUDIANTE_2 AS ee
                    INNER JOIN (
                        SELECT PERIODO
                        FROM CUN.MATRIZ_CALENDARIO
                        WHERE CONVERT(date, FI_CLASE, 103) < GETDATE()
                            AND CONVERT(date, FF_CLASE, 103) > GETDATE()
                    ) AS mc ON ee.COD_PERIODO = mc.PERIODO
                    WHERE ESTADO_ALUMNO = '1-Activo';";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@FechaActual", fechaActual);

                    // Ejecutar la consulta y obtener el resultado
                    cantidadEstudiantesActivos = (int)command.ExecuteScalar();
                }
            }

            return cantidadEstudiantesActivos;
        }


    }
}
