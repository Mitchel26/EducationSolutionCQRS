using AutoMapper;
using Education.Application.DTOs;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Education.Application.Cursos
{
    public class GetCursoByIdQuery
    {
        public class GetCursoQueryByIdRequest : IRequest<CursoDTO>
        {
            public Guid CursoId { get; set; }

        }
        public class GetCursoQueryByIdHandler : IRequestHandler<GetCursoQueryByIdRequest, CursoDTO>
        {
            private readonly EducationDbContext context;
            private readonly IMapper mapper;

            public GetCursoQueryByIdHandler(EducationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public async Task<CursoDTO> Handle(GetCursoQueryByIdRequest request, CancellationToken cancellationToken)
            {
                var curso = await context.Cursos.FirstOrDefaultAsync(c => c.CursoId == request.CursoId);
                if (curso is null)
                {
                    throw new Exception("No existe el curso");
                }
                return mapper.Map<CursoDTO>(curso);
            }
        }
    }
}
