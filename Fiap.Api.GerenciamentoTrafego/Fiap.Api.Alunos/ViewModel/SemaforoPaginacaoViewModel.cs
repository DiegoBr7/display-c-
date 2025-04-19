namespace Fiap.Api.Alunos.ViewModel
{
    public class SemaforoPaginacaoViewModel
    {
        public IEnumerable<SemaforoViewModel> Semaforos { get; set; }
        public int PaginaAtual { get; set; }
        public int TamanhoPagina { get; set; }
        public bool HasPreviousPage => PaginaAtual > 1;
        public bool HasNextPage => Semaforos.Count() == TamanhoPagina;
    }
}
