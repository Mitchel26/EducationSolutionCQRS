using Education.Domain;
using Microsoft.EntityFrameworkCore;

namespace Education.Persistence
{
    public class EducationDbContext : DbContext
    {
        public EducationDbContext()
        {
        }

        public EducationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Verifica si existe una configuracion
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=desktop\\sqlexpress;Initial Catalog=Education;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Agregando datos a la tabla cursos
            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Titulo = "Curso de Algoritmos",
                    Descripcion = "Fundamentos de programación",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(2),
                    Precio = 24
                });
            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Titulo = "Curso de Contabilidad",
                    Descripcion = "Fundamentos de contabilidad",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(2),
                    Precio = 30
                });
            modelBuilder.Entity<Curso>().HasData(
                new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Titulo = "Curso de NET6",
                    Descripcion = "Fundamentos de ASP.NET",
                    FechaCreacion = DateTime.Now,
                    FechaPublicacion = DateTime.Now.AddYears(2),
                    Precio = 250
                });

            // Presion de los decimales a la propiedad Precio 
            modelBuilder.Entity<Curso>().Property(c => c.Precio).HasPrecision(14, 2);
        }

        public DbSet<Curso> Cursos { get; set; }
    }
}
