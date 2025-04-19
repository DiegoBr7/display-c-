using Fiap.Api.Alunos.Models;

namespace Fiap.Api.Alunos.Services.Interfaces
{
    public interface ISemaforoService
    {
        IEnumerable<SemaforoModel> ListarSemaforos();
        IEnumerable<SemaforoModel> ListarSemaforos(int pagina = 0, int tamanho = 10);
        IEnumerable<SemaforoModel> ListarSemaforosUltimaReferencia(long ultimoId = 0, int tamanho = 10);
        SemaforoModel ObterSemaforoPorId(long id);
        void CriarSemaforo(SemaforoModel semaforo);
        void AtualizarSemaforo(SemaforoModel semaforo);
        void DeletarSemaforo(long id);
    }

}
