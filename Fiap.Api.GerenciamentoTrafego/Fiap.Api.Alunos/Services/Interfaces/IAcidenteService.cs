using Fiap.Api.Alunos.Models;

namespace Fiap.Api.Alunos.Services.Interfaces
{
    public interface IAcidenteService
    {
        IEnumerable<AcidenteModel> ListarAcidentes();
        IEnumerable<AcidenteModel> ListarAcidentes(int pagina = 0, int tamanho = 10);
        IEnumerable<AcidenteModel> ListarAcidentesUltimaReferencia(long ultimoId = 0, int tamanho = 10);
        AcidenteModel ObterAcidentePorId(long id);
        void CriarAcidente(AcidenteModel acidente);
        void AtualizarAcidente(AcidenteModel acidente);
        void DeletarAcidente(long id);
    }

}
