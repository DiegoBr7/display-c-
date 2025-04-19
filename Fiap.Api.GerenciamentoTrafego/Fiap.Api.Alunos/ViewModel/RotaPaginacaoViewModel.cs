namespace Fiap.Api.Alunos.ViewModel
{
    public class RotaPaginacaoViewModel
    {
        public IEnumerable<RotaViewModel> Rotas { get; set; }
        public int PaginaAtual { get; set; }
        public int TamanhoPagina { get; set; }
        public bool HasPreviousPage => PaginaAtual > 1;
        public bool HasNextPage => Rotas.Count() == TamanhoPagina;
    }
}
