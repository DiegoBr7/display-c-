namespace Fiap.Api.Alunos.Models
{
    public class CondicaoClimaticaModel
    {
        public long CondicaoClimaticaId { get; set; }
        public decimal? Temperatura { get; set; }
        public string? Umidade { get; set; }
        public Boolean? EstaChovendo { get; set; }
        public decimal? Visibilidade { get; set; }

        public DateTime DataHora { get; set; }

    }
}
