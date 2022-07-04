using Education.Domain;
using Education.Persistence;
using FluentValidation;
using MediatR;

namespace Education.Application.Cursos
{
    public class CreateCursoCommand
    {
        public class CreateCursoCommandRequest : IRequest
        {
            public string Titulo { get; set; }
            public string Descripcion { get; set; }
            public DateTime FechaPublicacion { get; set; }
            public Decimal Precio { get; set; }

        }
        public class CreateCursoCommandRequestValidation : AbstractValidator<CreateCursoCommandRequest>
        {
            public CreateCursoCommandRequestValidation()
            {
                RuleFor(c => c.Titulo).NotEmpty();
                RuleFor(c => c.Descripcion).NotEmpty();
            }
        }

        public class CreateCursoCommandHandler : IRequestHandler<CreateCursoCommandRequest>
        {
            private readonly EducationDbContext context;

            public CreateCursoCommandHandler(EducationDbContext context)
            {
                this.context = context;
            }
            public async Task<Unit> Handle(CreateCursoCommandRequest request, CancellationToken cancellationToken)
            {
                Curso curso = new Curso
                {
                    CursoId = Guid.NewGuid(),
                    Titulo = request.Titulo,
                    Descripcion = request.Descripcion,
                    FechaPublicacion = request.FechaPublicacion,
                    FechaCreacion = DateTime.Now,
                    Precio = request.Precio
                };

                context.Add(curso);
                var resultado = await context.SaveChangesAsync();

                if (resultado > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se inserto el curso");
            }
        }
    }
}
