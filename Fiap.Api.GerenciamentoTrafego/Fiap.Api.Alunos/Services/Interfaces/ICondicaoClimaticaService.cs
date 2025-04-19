using Fiap.Api.Alunos.Models;

namespace Fiap.Api.Alunos.Services.Interfaces
{
    public interface ICondicaoClimaticaService
    {
        IEnumerable<CondicaoClimaticaModel> ListarCondicoesClimaticas();
        IEnumerable<CondicaoClimaticaModel> ListarCondicoesClimaticas(int pagina = 0, int tamanho = 10);
        IEnumerable<CondicaoClimaticaModel> ListarCondicoesClimaticasUltimaReferencia(long ultimoId = 0, int tamanho = 10);
        CondicaoClimaticaModel ObterCondicaoClimaticaPorId(long id);
        void CriarCondicaoClimatica(CondicaoClimaticaModel condicaoClimatica);
        void AtualizarCondicaoClimatica(CondicaoClimaticaModel condicaoClimatica);
        void DeletarCondicaoClimatica(long id);
    }

}
