namespace Fiap.Api.Alunos.ViewModel
{
    public class AcidenteCreateViewModel
    {
        public required string Localizacao { get; set; }
        public required string Gravidade { get; set; }
        public DateTime Data { get; set; }
    }
}
