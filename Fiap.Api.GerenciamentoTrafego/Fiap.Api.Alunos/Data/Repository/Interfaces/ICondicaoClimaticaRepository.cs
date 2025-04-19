using Fiap.Api.Alunos.Models;

namespace Fiap.Api.Alunos.Data.Repository.Interfaces
{
    public interface ICondicaoClimaticaRepository
    {
        IEnumerable<CondicaoClimaticaModel> GetAll();

        IEnumerable<CondicaoClimaticaModel> GetAll(int page, int size);

        IEnumerable<CondicaoClimaticaModel> GetAllReference(long lastReference, int size);

        CondicaoClimaticaModel GetById(long id);
        void Add(CondicaoClimaticaModel condicaoClimatica);
        void Update(CondicaoClimaticaModel condicaoClimatica);
        void Delete(CondicaoClimaticaModel condicaoClimatica);
    }
}
