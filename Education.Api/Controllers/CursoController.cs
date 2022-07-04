using Education.Application.Cursos;
using Education.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Education.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private IMediator mediator;

        public CursoController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<CursoDTO>>> Get()
        {
            return await mediator.Send(new GetCursoQuery.GetCursoQueryRequest());
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Post(CreateCursoCommand.CreateCursoCommandRequest parametros)
        {
            return await mediator.Send(parametros);
        }
    }
}
