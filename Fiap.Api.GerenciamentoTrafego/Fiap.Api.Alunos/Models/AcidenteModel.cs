namespace Fiap.Api.Alunos.Models
{
    public class AcidenteModel
    {
        public long AcidenteId { get; set; }
        public required string Localizacao { get; set; }
        public required string Gravidade { get; set; }
        public DateTime DataHora { get; set; }

    }
}
