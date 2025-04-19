using Fiap.Api.Alunos.Models;

namespace Fiap.Api.Alunos.Data.Repository.Interfaces
{
    public interface ISemaforoRepository
    {
        IEnumerable<SemaforoModel> GetAll();

        IEnumerable<SemaforoModel> GetAll(int page, int size);

        IEnumerable<SemaforoModel> GetAllReference(long lastReference, int size);

        SemaforoModel GetById(long id);
        void Add(SemaforoModel semaforo);
        void Update(SemaforoModel semaforo);
        void Delete(SemaforoModel semaforo);
    }
}
