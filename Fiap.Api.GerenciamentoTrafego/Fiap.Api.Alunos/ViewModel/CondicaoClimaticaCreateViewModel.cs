namespace Fiap.Api.Alunos.ViewModel
{
    public class CondicaoClimaticaCreateViewModel
    {
        public decimal? Temperatura { get; set; }
        public decimal? Umidade { get; set; }
        public Boolean? EstaChovendo { get; set; }
        public decimal? Visibilidade { get; set; }
        public DateTime DataHora { get; set; }
    }
}
