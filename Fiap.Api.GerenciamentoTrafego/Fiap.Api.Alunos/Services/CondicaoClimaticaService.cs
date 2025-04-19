using Fiap.Api.Alunos.Data.Repository.Interfaces;
using Fiap.Api.Alunos.Models;
using Fiap.Api.Alunos.Services.Interfaces;

namespace Fiap.Api.Alunos.Services
{
    public class CondicaoClimaticaService : ICondicaoClimaticaService
    {
        private readonly ICondicaoClimaticaRepository _repository;

        public CondicaoClimaticaService(ICondicaoClimaticaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<CondicaoClimaticaModel> ListarCondicoesClimaticas() => _repository.GetAll();

        public IEnumerable<CondicaoClimaticaModel> ListarCondicoesClimaticas(int pagina = 1, int tamanho = 10)
        {
            return _repository.GetAll(pagina,tamanho);
        }

        public IEnumerable<CondicaoClimaticaModel> ListarCondicoesClimaticasUltimaReferencia(long ultimoId = 0, int tamanho = 10) 
        {
            return _repository.GetAllReference(ultimoId, tamanho);
        } 

        public CondicaoClimaticaModel ObterCondicaoClimaticaPorId(long id) => _repository.GetById(id);

        public void CriarCondicaoClimatica(CondicaoClimaticaModel condicaoClimatica) => _repository.Add(condicaoClimatica);        

        public void AtualizarCondicaoClimatica(CondicaoClimaticaModel condicaoClimatica) => _repository.Update(condicaoClimatica);

        public void DeletarCondicaoClimatica(long id)
        {
            var condicaoClimatica = _repository.GetById(id);
            if (condicaoClimatica != null)
            {
                _repository.Delete(condicaoClimatica);
            }
        }

    }
}
