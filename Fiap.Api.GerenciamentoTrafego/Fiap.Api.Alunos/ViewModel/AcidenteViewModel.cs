namespace Fiap.Api.Alunos.ViewModel
{
    public class AcidenteViewModel
    {
        public long AcidenteId { get; set; }
        public required string Localizacao { get; set; }
        public required string Gravidade { get; set; }
        public DateTime DataHora { get; set; }
    }
}
