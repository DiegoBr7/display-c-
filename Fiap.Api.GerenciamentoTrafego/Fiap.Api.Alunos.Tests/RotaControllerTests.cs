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
    public class RotaControllerTests
    {
        // Mocks dos serviços e do mapper
        private readonly Mock<IRotaService> _mockRotaService;
        private readonly Mock<IMapper> _mockMapper;

        // Controlador que será testado
        private readonly RotaController _controller;

        public RotaControllerTests()
        {
            // Inicializa os mocks
            _mockRotaService = new Mock<IRotaService>();
            _mockMapper = new Mock<IMapper>();

            // Inicializa o controller com os serviços e mapper mockados
            _controller = new RotaController(_mockRotaService.Object, _mockMapper.Object);
        }

        // Método para criar e configurar um DbSet mock para RotaModel
        private DbSet<RotaModel> MockDbSet()
        {
            // Lista de Rotas para simular dados no banco de dados
            var data = new List<RotaModel>
            {
                new RotaModel { RotaId = 1, Origem = "Lugar 1", Destino = "Lugar 2" },
                new RotaModel { RotaId = 2, Origem = "Lugar 3", Destino = "Lugar 4" }
            }.AsQueryable();

            // Cria o mock do DbSet
            var mockSet = new Mock<DbSet<RotaModel>>();

            // Configura o comportamento do mock DbSet para simular uma consulta ao banco de dados
            mockSet.As<IQueryable<RotaModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<RotaModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<RotaModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<RotaModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            // Retorna o DbSet mock
            return mockSet.Object;
        }

        [Fact]
        public void Get_ReturnsHttpStatusCode200()
        {
            // Arrange
            var Rotas = new List<RotaModel>
            {
                new RotaModel { RotaId = 1, Origem = "Lugar 1", Destino = "Lugar 2" },
                new RotaModel { RotaId = 2, Origem = "Lugar 3", Destino = "Lugar 4" }
            };
            var RotaViewModels = Rotas.Select(c => new RotaViewModel { RotaId = c.RotaId, Origem = c.Origem, Destino = c.Destino });

            var mockService = new Mock<IRotaService>();
            mockService.Setup(s => s.ListarRotas()).Returns(Rotas);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<IEnumerable<RotaViewModel>>(Rotas)).Returns(RotaViewModels);

            var controller = new RotaController(mockService.Object, mockMapper.Object);

            // Act
            var result = controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result); // Confirma se o retorno é Ok
            Assert.Equal(200, okResult.StatusCode); // Confirma se o código de status é 200
        }
    }
}