using AutoMapper;
using Education.Application.DTOs;
using Education.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Education.Application.Cursos
{
    public class GetCursoQuery
    {
        public class GetCursoQueryRequest : IRequest<List<CursoDTO>> { }
        public class GetCursoQueryHandler : IRequestHandler<GetCursoQueryRequest, List<CursoDTO>>
        {
            private readonly EducationDbContext context;
            private readonly IMapper mapper;

            public GetCursoQueryHandler(EducationDbContext context, IMapper mapper)
            {
                this.context = context;
                this.mapper = mapper;
            }
            public async Task<List<CursoDTO>> Handle(GetCursoQueryRequest request, CancellationToken cancellationToken)
            {
                var cursos = await context.Cursos.ToListAsync();
                return mapper.Map<List<CursoDTO>>(cursos);
            }
        }
    }
}
