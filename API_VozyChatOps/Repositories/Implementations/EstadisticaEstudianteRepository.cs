using API_VozyChatOps.Data;
using API_VozyChatOps.DTOs;
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

        public async Task<EstudianteActivoResponseDTO> ObtenerEstudiantesActivosPorIdentificacion(EstudianteActivoRequestDTO estudianteActivoRequestDTO)
        {
            EstudianteActivoResponseDTO estudiante = null;

            // Cadena de conexión a tu base de datos
            string connectionString = "Server=172.16.1.33;Database=CUN_REPOSITORIO;User=vozy_chat_api;Password=4n4lyt1cs2024*;Encrypt=True;TrustServerCertificate=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT *
                    FROM CUN.ESTADISTICA_ESTUDIANTE_2 AS ee
                    INNER JOIN (
                        SELECT PERIODO
                        FROM CUN.MATRIZ_CALENDARIO
                        WHERE CONVERT(date, FI_CLASE, 103) < GETDATE()
                            AND CONVERT(date, FF_CLASE, 103) > GETDATE()
                    ) AS mc ON ee.COD_PERIODO = mc.PERIODO
                    WHERE ESTADO_ALUMNO = '1-Activo' AND NUM_IDENTIFICACION = @NumIdentificacion;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Agrega parámetros para evitar SQL injection
                    command.Parameters.AddWithValue("@NumIdentificacion", estudianteActivoRequestDTO.NumIdentificacion);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Mapea los resultados a tu modelo de EstadisticaEstudiante
                            estudiante = new EstudianteActivoResponseDTO
                            {
                                // Asigna los valores según las columnas de tu consulta
                                // Por ejemplo:
                                // NUM_IDENTIFICACION = reader["NUM_IDENTIFICACION"].ToString(),
                                // Otros campos...
                                NUM_IDENTIFICACION = reader["NUM_IDENTIFICACION"].ToString(),
                                NOM_TERCERO = reader["NOM_TERCERO"].ToString(),
                                SEG_NOMBRE = reader["SEG_NOMBRE"].ToString(),
                                PRI_APELLIDO = reader["PRI_APELLIDO"].ToString(),
                                SEG_APELLIDO = reader["SEG_APELLIDO"].ToString(),
                                DIR_EMAIL_PER = reader["DIR_EMAIL_PER"].ToString(),
                                DIR_EMAIL = reader["DIR_EMAIL"].ToString(),
                                ESTADO_ALUMNO = reader["ESTADO_ALUMNO"].ToString(),

                            };
                        }
                    }
                }
            }
            return estudiante;
        }

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
