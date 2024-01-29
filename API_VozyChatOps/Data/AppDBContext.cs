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


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ScheduleModel>()
                .HasKey(s => new { s.NUM_IDENTIFICACION }); // Clave primaria compuesta

            // Otras configuraciones

            base.OnModelCreating(modelBuilder);
        }


    }
}
