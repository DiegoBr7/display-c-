using Fiap.Api.Alunos.Data.Repository.Interfaces;
using Fiap.Api.Alunos.Models;
using Fiap.Api.Alunos.Services.Interfaces;

namespace Fiap.Api.Alunos.Services
{
    public class SemaforoService : ISemaforoService
    {
        private readonly ISemaforoRepository _repository;

        public SemaforoService(ISemaforoRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<SemaforoModel> ListarSemaforos() => _repository.GetAll();

        public IEnumerable<SemaforoModel> ListarSemaforos(int pagina = 1, int tamanho = 10)
        {
            return _repository.GetAll(pagina,tamanho);
        }

        public IEnumerable<SemaforoModel> ListarSemaforosUltimaReferencia(long ultimoId = 0, int tamanho = 10) 
        {
            return _repository.GetAllReference(ultimoId, tamanho);
        } 

        public SemaforoModel ObterSemaforoPorId(long id) => _repository.GetById(id);

        public void CriarSemaforo(SemaforoModel semaforo) => _repository.Add(semaforo);        

        public void AtualizarSemaforo(SemaforoModel semaforo) => _repository.Update(semaforo);

        public void DeletarSemaforo(long id)
        {
            var semaforo = _repository.GetById(id);
            if (semaforo != null)
            {
                _repository.Delete(semaforo);
            }
        }
    }
}
