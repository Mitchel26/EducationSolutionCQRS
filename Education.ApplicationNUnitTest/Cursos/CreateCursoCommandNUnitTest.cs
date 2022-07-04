using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace Education.Application.Cursos
{
    [TestFixture]
    public class CreateCursoCommandNUnitTest
    {
        private CreateCursoCommand.CreateCursoCommandHandler handleCreateCurso;

        [SetUp]
        public void Setup()
        {
            var fixture = new Fixture();  // la libreria AutoFixture permite generar data falsa para las pruebas
            var cursoRecords = fixture.CreateMany<Curso>().ToList();  // Creando objetos de tipo curso

            // Creo una new instancia (copia) de las opciones del dbcontext (EducationDbContext) para ejecutarlos en memoria
            var options = new DbContextOptionsBuilder<EducationDbContext>()
                              .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
                              .Options;

            var educationDbContextFake = new EducationDbContext(options);  // Creando el DbContext de prueba
            educationDbContextFake.Cursos.AddRange(cursoRecords);  // Agredo los cursoRecors generados al Dbcontext de prueba(educationDbContextFake)
            educationDbContextFake.SaveChanges();

            // Seteando el valor a la propiedad handleAllCursos que es la instancia de la clase GetCursoQuery.GetCursoQueryByIdHandler
            handleCreateCurso = new CreateCursoCommand.CreateCursoCommandHandler(educationDbContextFake);

        }

        [Test]
        public async Task CreateCursoCommand_CreateCurso_ReturnNumber()
        {
            CreateCursoCommand.CreateCursoCommandRequest request = new CreateCursoCommand.CreateCursoCommandRequest()
            {
                FechaPublicacion = DateTime.Now.AddDays(59),
                Descripcion = "Aprende a crear Unit test desde cero",
                Titulo = "Libro de pruebas unitarias .NET6",
                Precio = 110
            };
            var resultado = await handleCreateCurso.Handle(request, new System.Threading.CancellationToken());

            Assert.That(resultado, Is.EqualTo(Unit.Value));
        }
    }
}
