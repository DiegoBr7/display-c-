using Fiap.Api.Alunos.Data.Repository.Interfaces;
using Fiap.Api.Alunos.Models;
using Fiap.Api.Alunos.Services.Interfaces;

namespace Fiap.Api.Alunos.Services
{
    public class AcidenteService : IAcidenteService
    {
        private readonly IAcidenteRepository _repository;

        public AcidenteService(IAcidenteRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<AcidenteModel> ListarAcidentes() => _repository.GetAll();

        public IEnumerable<AcidenteModel> ListarAcidentes(int pagina = 1, int tamanho = 10)
        {
            return _repository.GetAll(pagina,tamanho);
        }

        public IEnumerable<AcidenteModel> ListarAcidentesUltimaReferencia(long ultimoId = 0, int tamanho = 10) 
        {
            return _repository.GetAllReference(ultimoId, tamanho);  
        } 

        public AcidenteModel ObterAcidentePorId(long id) => _repository.GetById(id);

        public void CriarAcidente(AcidenteModel acidente) => _repository.Add(acidente);        

        public void AtualizarAcidente(AcidenteModel acidente) => _repository.Update(acidente);

        public void DeletarAcidente(long id)
        {
            var acidente = _repository.GetById(id);
            if (acidente != null)
            {
                _repository.Delete(acidente);
            }
        }

    }
}
