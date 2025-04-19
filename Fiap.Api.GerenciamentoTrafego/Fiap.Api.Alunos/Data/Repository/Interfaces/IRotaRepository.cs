using Fiap.Api.Alunos.Models;

namespace Fiap.Api.Alunos.Data.Repository.Interfaces
{
    public interface IRotaRepository
    {
        IEnumerable<RotaModel> GetAll();

        IEnumerable<RotaModel> GetAll(int page, int size);

        IEnumerable<RotaModel> GetAllReference(long lastReference, int size);

        RotaModel GetById(long id);
        void Add(RotaModel rota);
        void Update(RotaModel rota);
        void Delete(RotaModel rota);
    }
}
