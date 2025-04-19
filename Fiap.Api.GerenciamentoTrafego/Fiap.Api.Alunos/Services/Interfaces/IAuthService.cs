using Fiap.Api.Alunos.Models;

namespace Fiap.Api.Alunos.Services.Interfaces
{
    public interface IAuthService
    {
        UserModel Authenticate(string username, string password);

    }
}