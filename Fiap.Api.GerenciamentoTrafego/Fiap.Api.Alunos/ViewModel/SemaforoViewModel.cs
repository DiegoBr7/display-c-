namespace Fiap.Api.Alunos.ViewModel
{
    public class SemaforoViewModel
    {
        public long SemaforoId { get; set; }
        public required string Localizacao { get; set; }
        public required string Status { get; set; }
        public int? fluxoTrafego { get; set; }
        public DateTime DataHora { get; set; }
    }
}
