using Fiap.Api.Alunos.Models;

namespace Fiap.Api.Alunos.Data.Repository.Interfaces
{
    public interface IAcidenteRepository
    {
        IEnumerable<AcidenteModel> GetAll();

        IEnumerable<AcidenteModel> GetAll(int page, int size);

        IEnumerable<AcidenteModel> GetAllReference(long lastReference, int size);

        AcidenteModel GetById(long id);
        void Add(AcidenteModel acidente);
        void Update(AcidenteModel acidente);
        void Delete(AcidenteModel acidente);
    }
}
