using AutoMapper;
using Education.Application.DTOs;
using Education.Domain;

namespace Education.Application.Mapping
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Curso, CursoDTO>();
        }
    }
}
