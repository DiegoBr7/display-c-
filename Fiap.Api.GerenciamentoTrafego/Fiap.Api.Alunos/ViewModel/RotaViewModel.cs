namespace Fiap.Api.Alunos.ViewModel
{
    public class RotaViewModel
    {
        public long RotaId { get; set; }
        public required string Origem { get; set; }
        public required string Destino { get; set; }
        public Boolean? Congestionada { get; set; }
        public decimal? Duracao { get; set; }
        public DateTime DataHora { get; set; }
    }
}
