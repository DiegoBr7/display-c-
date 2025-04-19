using AutoMapper;
using Fiap.Api.Alunos.Controllers;
using Fiap.Api.Alunos.Data.Contexts;
using Fiap.Api.Alunos.Models;
using Fiap.Api.Alunos.Services.Interfaces;
using Fiap.Api.Alunos.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Fiap.Api.Alunos.Tests
{
    public class SemaforoControllerTests
    {
        // Mocks dos serviços e do mapper
        private readonly Mock<ISemaforoService> _mockSemaforoService;
        private readonly Mock<IMapper> _mockMapper;

        // Controlador que será testado
        private readonly SemaforoController _controller;

        public SemaforoControllerTests()
        {
            // Inicializa os mocks
            _mockSemaforoService = new Mock<ISemaforoService>();
            _mockMapper = new Mock<IMapper>();

            // Inicializa o controller com os serviços e mapper mockados
            _controller = new SemaforoController(_mockSemaforoService.Object, _mockMapper.Object);
        }

        // Método para criar e configurar um DbSet mock para SemaforoModel
        private DbSet<SemaforoModel> MockDbSet()
        {
            // Lista de Semaforos para simular dados no banco de dados
            var data = new List<SemaforoModel>
            {
                new SemaforoModel { SemaforoId = 1, Localizacao = "Semaforo 1", Status = "Ativo" },
                new SemaforoModel { SemaforoId = 2, Localizacao = "Semaforo 2", Status = "Inativo" }
            }.AsQueryable();

            // Cria o mock do DbSet
            var mockSet = new Mock<DbSet<SemaforoModel>>();

            // Configura o comportamento do mock DbSet para simular uma consulta ao banco de dados
            mockSet.As<IQueryable<SemaforoModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<SemaforoModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<SemaforoModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<SemaforoModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            // Retorna o DbSet mock
            return mockSet.Object;
        }

        [Fact]
        public void Get_ReturnsHttpStatusCode200()
        {
            // Arrange
            var Semaforos = new List<SemaforoModel>
            {
                new SemaforoModel { SemaforoId = 1, Localizacao = "Semaforo 1", Status = "Ativo" },
                new SemaforoModel { SemaforoId = 2, Localizacao = "Semaforo 2", Status = "Inativo" }
            };
            var SemaforoViewModels = Semaforos.Select(c => new SemaforoViewModel { SemaforoId = c.SemaforoId, Localizacao = c.Localizacao, Status = c.Status });

            var mockService = new Mock<ISemaforoService>();
            mockService.Setup(s => s.ListarSemaforos()).Returns(Semaforos);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<IEnumerable<SemaforoViewModel>>(Semaforos)).Returns(SemaforoViewModels);

            var controller = new SemaforoController(mockService.Object, mockMapper.Object);

            // Act
            var result = controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result); // Confirma se o retorno é Ok
            Assert.Equal(200, okResult.StatusCode); // Confirma se o código de status é 200
        }
    }
}