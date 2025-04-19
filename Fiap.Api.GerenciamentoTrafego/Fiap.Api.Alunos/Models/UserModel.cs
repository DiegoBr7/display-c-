namespace Fiap.Api.Alunos.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }  // Em produção, nunca armazene senhas em texto claro.
        public string? Role { get; set; }
    }
}
