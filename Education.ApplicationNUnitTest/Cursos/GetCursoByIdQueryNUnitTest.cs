using AutoFixture;
using AutoMapper;
using Education.Application.Helper;
using Education.Domain;
using Education.Persistence;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Application.Cursos
{
    public class GetCursoByIdQueryNUnitTest
    {
        private GetCursoByIdQuery.GetCursoQueryByIdHandler handleByIdCursos;
        private Guid CursoIdTest;

        [SetUp]
        public void Setup()
        {

            CursoIdTest = new Guid("A7788DFA-14E7-43DF-A19D-76D6C95EB041");

            var fixture = new Fixture();  // la libreria AutoFixture permite generar data falsa para las pruebas
            var cursoRecords = fixture.CreateMany<Curso>().ToList();  // Creando objetos de tipo curso

            cursoRecords.Add(fixture.Build<Curso>().With(tr => tr.CursoId, CursoIdTest).Create()); // Creo un objeto tipo curso sin Id (para probar GetByIdQuery)

            // Creo una new instancia (copia) de las opciones del dbcontext (EducationDbContext) para ejecutarlos en memoria
            var options = new DbContextOptionsBuilder<EducationDbContext>()
                              .UseInMemoryDatabase(databaseName: $"EducationDbContext-{Guid.NewGuid()}")
                              .Options;


            var educationDbContextFake = new EducationDbContext(options);  // Creando el DbContext de prueba
            educationDbContextFake.Cursos.AddRange(cursoRecords);  // Agredo los cursoRecors generados al Dbcontext de prueba(educationDbContextFake)
            educationDbContextFake.SaveChanges();

            // Configuración de AutoMapper
            var mapConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingTest());
            });

            // creando AutoMapper con la configuraciones del clases MappingTest
            var mapper = mapConfig.CreateMapper();


            // Seteando el valor a la propiedad handleAllCursos que es la instancia de la clase GetCursoQuery.GetCursoQueryByIdHandler
            handleByIdCursos = new GetCursoByIdQuery.GetCursoQueryByIdHandler(educationDbContextFake, mapper);

        }

        [Test]
        public async Task GetCursoQueryHandler_ConsultaCursos_ReturnTrue()
        {
            GetCursoByIdQuery.GetCursoQueryByIdRequest request = new()
            {
                CursoId = CursoIdTest
            };
            var curso = await handleByIdCursos.Handle(request, new System.Threading.CancellationToken());

            Assert.IsNotNull(curso);
        }
    }
}
