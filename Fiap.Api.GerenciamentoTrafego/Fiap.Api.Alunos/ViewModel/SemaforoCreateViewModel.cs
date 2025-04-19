namespace Fiap.Api.Alunos.ViewModel
{
    public class SemaforoCreateViewModel
    {
        public required string Localizacao { get; set; }
        public required string Status { get; set; }
        public int? fluxoTrafego { get; set; }
        public DateTime DataHora { get; set; }
    }
}
