using AutoMapper;
using Education.Application.DTOs;
using Education.Domain;

namespace Education.Application.Helper
{
    public class MappingTest: Profile
    {
        public MappingTest()
        {
            CreateMap<Curso, CursoDTO>();
        }
    }
}
