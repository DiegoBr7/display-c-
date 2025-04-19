using Fiap.Api.Alunos.ViewModel;
using Fiap.Api.Alunos.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Fiap.Api.Alunos.Services.Interfaces;
using Asp.Versioning;

namespace Fiap.Api.Alunos.Controllers
{
    [ApiVersion(1)]
    [ApiVersion(2)]
    [ApiController]
    [Route("api/v{v:apiVersion}/[controller]")]
    [Authorize]
    public class SemaforoController : ControllerBase
    {
        private readonly ISemaforoService _service;
        private readonly IMapper _mapper;

        public SemaforoController(ISemaforoService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<SemaforoViewModel>> Get()
        {
            var semaforos = _service.ListarSemaforos();
            var viewModelList = _mapper.Map<IEnumerable<SemaforoViewModel>>(semaforos);
            return Ok(viewModelList);
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpGet("{id:long}")]
        [AllowAnonymous]
        public ActionResult<SemaforoViewModel> GetById(long id)
        {
            var semaforo = _service.ObterSemaforoPorId(id);
            if (semaforo == null)
                return NotFound();

            var viewModel = _mapper.Map<SemaforoViewModel>(semaforo);
            return Ok(viewModel);
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpPost]
        [Authorize(Roles = "gerente,analista")]
        public ActionResult Post([FromBody] SemaforoCreateViewModel viewModel)
        {
            var semaforo = _mapper.Map<SemaforoModel>(viewModel);
            _service.CriarSemaforo(semaforo);
            return CreatedAtAction(nameof(GetById), new { id = semaforo.SemaforoId }, semaforo);
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpPut("{id:long}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Put(long id, [FromBody] SemaforoViewModel viewModel)
        {
            var semaforoExistente = _service.ObterSemaforoPorId(id);
            if (semaforoExistente == null)
                return NotFound();

            _mapper.Map(viewModel, semaforoExistente);
            _service.AtualizarSemaforo(semaforoExistente);
            return NoContent();
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpDelete("{id:long}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Delete(long id)
        {
            _service.DeletarSemaforo(id);
            return NoContent();
        }
    }
}
