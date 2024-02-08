using API_VozyChatOps.Models;
using Microsoft.EntityFrameworkCore;

namespace API_VozyChatOps.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {

        }

        public DbSet<ScheduleModel> Horarios { get; set; }
        public DbSet<EstadisticaEstudianteModel> EstadisticaEstudiantes { get; set; }
        public DbSet<MatrizCalendarioModel> MatrizCalendarios { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<ScheduleModel>()
            //.HasKey(s => new { s.NUM_IDENTIFICACION }); // Clave primaria compuesta
            modelBuilder.Entity<ScheduleModel>().HasNoKey();
            modelBuilder.Entity<EstadisticaEstudianteModel>().HasNoKey();
            modelBuilder.Entity<MatrizCalendarioModel>().HasNoKey();

            // Otras configuraciones

            base.OnModelCreating(modelBuilder);
        }


    }
}
