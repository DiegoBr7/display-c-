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
    public class AcidenteController : ControllerBase
    {
        private readonly IAcidenteService _service;
        private readonly IMapper _mapper;

        public AcidenteController(IAcidenteService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpGet]
        [AllowAnonymous]
        public ActionResult<IEnumerable<AcidenteViewModel>> Get()
        {
            var acidentes = _service.ListarAcidentes();
            var viewModelList = _mapper.Map<IEnumerable<AcidenteViewModel>>(acidentes);
            return Ok(viewModelList);
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpGet("{id:long}")]
        [AllowAnonymous]
        public ActionResult<AcidenteViewModel> GetById(long id)
        {
            var acidente = _service.ObterAcidentePorId(id);
            if (acidente == null)
                return NotFound();

            var viewModel = _mapper.Map<AcidenteViewModel>(acidente);
            return Ok(viewModel);
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpPost]
        [Authorize(Roles = "gerente,analista")]
        public ActionResult Post([FromBody] AcidenteCreateViewModel viewModel)
        {
            var acidente = _mapper.Map<AcidenteModel>(viewModel);
            _service.CriarAcidente(acidente);
            return CreatedAtAction(nameof(GetById), new { id = acidente.AcidenteId }, acidente);
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpPut("{id:long}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Put(long id, [FromBody] AcidenteViewModel viewModel)
        {
            var acidenteExistente = _service.ObterAcidentePorId(id);
            if (acidenteExistente == null)
                return NotFound();

            _mapper.Map(viewModel, acidenteExistente);
            _service.AtualizarAcidente(acidenteExistente);
            return NoContent();
        }

        [MapToApiVersion(1)]
        [MapToApiVersion(2)]
        [HttpDelete("{id:long}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Delete(long id)
        {
            _service.DeletarAcidente(id);
            return NoContent();
        }
    }
}
