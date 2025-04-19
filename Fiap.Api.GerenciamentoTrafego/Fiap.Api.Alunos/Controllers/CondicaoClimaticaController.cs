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
    public class CondicaoClimaticaController : ControllerBase
    {
        private readonly ICondicaoClimaticaService _service;
        private readonly IMapper _mapper;

        public CondicaoClimaticaController(ICondicaoClimaticaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpGet]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<IEnumerable<CondicaoClimaticaViewModel>> Get()
        {
            var condicoesClimaticas = _service.ListarCondicoesClimaticas();
            var viewModelList = _mapper.Map<IEnumerable<CondicaoClimaticaViewModel>>(condicoesClimaticas);
            return Ok(viewModelList);
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpGet("{id:long}")]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<CondicaoClimaticaViewModel> GetById(long id)
        {
            var condicaoClimatica = _service.ObterCondicaoClimaticaPorId(id);
            if (condicaoClimatica == null)
                return NotFound();

            var viewModel = _mapper.Map<CondicaoClimaticaViewModel>(condicaoClimatica);
            return Ok(viewModel);
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpPost]
        [Authorize(Roles = "gerente,analista")]
        public ActionResult Post([FromBody] CondicaoClimaticaCreateViewModel viewModel)
        {
            var condicaoClimatica = _mapper.Map<CondicaoClimaticaModel>(viewModel);
            _service.CriarCondicaoClimatica(condicaoClimatica);
            return CreatedAtAction(nameof(GetById), new { id = condicaoClimatica.CondicaoClimaticaId }, condicaoClimatica);
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpPut("{id:long}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Put(long id, [FromBody] CondicaoClimaticaViewModel viewModel)
        {
            var condicaoClimaticaExistente = _service.ObterCondicaoClimaticaPorId(id);
            if (condicaoClimaticaExistente == null)
                return NotFound();

            _mapper.Map(viewModel, condicaoClimaticaExistente);
            _service.AtualizarCondicaoClimatica(condicaoClimaticaExistente);
            return NoContent();
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpDelete("{id:long}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Delete(long id)
        {
            _service.DeletarCondicaoClimatica(id);
            return NoContent();
        }
    }
}
