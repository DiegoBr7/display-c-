using Fiap.Api.Alunos.Data.Repository.Interfaces;
using Fiap.Api.Alunos.Models;
using Fiap.Api.Alunos.Services.Interfaces;

namespace Fiap.Api.Alunos.Services
{
    public class RotaService : IRotaService
    {
        private readonly IRotaRepository _repository;

        public RotaService(IRotaRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<RotaModel> ListarRotas() => _repository.GetAll();

        public IEnumerable<RotaModel> ListarRotas(int pagina = 1, int tamanho = 10)
        {
            return _repository.GetAll(pagina,tamanho);
        }

        public IEnumerable<RotaModel> ListarRotasUltimaReferencia(long ultimoId = 0, int tamanho = 10) 
        {
            return _repository.GetAllReference(ultimoId, tamanho);
        } 

        public RotaModel ObterRotaPorId(long id) => _repository.GetById(id);

        public void CriarRota(RotaModel rota) => _repository.Add(rota);        

        public void AtualizarRota(RotaModel rota) => _repository.Update(rota);

        public void DeletarRota(long id)
        {
            var rota = _repository.GetById(id);
            if (rota != null)
            {
                _repository.Delete(rota);
            }
        }
    }
}
