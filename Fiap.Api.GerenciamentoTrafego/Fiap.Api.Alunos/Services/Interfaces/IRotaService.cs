using Fiap.Api.Alunos.Models;

namespace Fiap.Api.Alunos.Services.Interfaces
{
    public interface IRotaService
    {
        IEnumerable<RotaModel> ListarRotas();
        IEnumerable<RotaModel> ListarRotas(int pagina = 0, int tamanho = 10);
        IEnumerable<RotaModel> ListarRotasUltimaReferencia(long ultimoId = 0, int tamanho = 10);
        RotaModel ObterRotaPorId(long id);
        void CriarRota(RotaModel rota);
        void AtualizarRota(RotaModel rota);
        void DeletarRota(long id);
    }

}
