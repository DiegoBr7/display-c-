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
    public class RotaController : ControllerBase
	{
		private readonly IRotaService _service;
		private readonly IMapper _mapper;

		public RotaController(IRotaService service, IMapper mapper)
		{
			_service = service;
			_mapper = mapper;
		}

		[MapToApiVersion(1)]
		[MapToApiVersion(2)]
		[HttpGet]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<IEnumerable<RotaViewModel>> Get()
        {
            var rotas = _service.ListarRotas();
            var viewModelList = _mapper.Map<IEnumerable<RotaViewModel>>(rotas);
            return Ok(viewModelList);
        }

		[MapToApiVersion(1)]
		[MapToApiVersion(2)]
		[HttpGet("{id:long}")]
        [Authorize(Roles = "operador,analista,gerente")]
        public ActionResult<RotaViewModel> GetById(long id)
		{
            var rota = _service.ObterRotaPorId(id);
            if (rota == null)
                return NotFound();

            var viewModel = _mapper.Map<RotaViewModel>(rota);
            return Ok(viewModel);
        }

		[MapToApiVersion(1)]
		[MapToApiVersion(2)]
		[HttpPost]
        [Authorize(Roles = "gerente,analista")]
        public ActionResult Post([FromBody] RotaCreateViewModel viewModel)
		{
			var rota = _mapper.Map<RotaModel>(viewModel);
			_service.CriarRota(rota);
			return CreatedAtAction(nameof(GetById), new { id = rota.RotaId }, rota);
		}

		[MapToApiVersion(1)]
		[MapToApiVersion(2)]
		[HttpPut("{id:long}")]
		[Authorize(Roles = "gerente")]
        public ActionResult Put(long id, [FromBody] RotaViewModel viewModel)
        {
            var rotaExistente = _service.ObterRotaPorId(id);
            if (rotaExistente == null)
                return NotFound();

            _mapper.Map(viewModel, rotaExistente);
            _service.AtualizarRota(rotaExistente);
            return NoContent();
		}

		[MapToApiVersion(1)]
		[MapToApiVersion(2)]
		[HttpDelete("{id:long}")]
        [Authorize(Roles = "gerente")]
        public ActionResult Delete(long id)
		{
			_service.DeletarRota(id);
			return NoContent();
		}
	}
}
