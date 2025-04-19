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
    public class CondicaoClimaticaControllerTests
    {
        // Mocks dos serviços e do mapper
        private readonly Mock<ICondicaoClimaticaService> _mockCondicaoClimaticaService;
        private readonly Mock<IMapper> _mockMapper;

        // Controlador que será testado
        private readonly CondicaoClimaticaController _controller;

        public CondicaoClimaticaControllerTests()
        {
            // Inicializa os mocks
            _mockCondicaoClimaticaService = new Mock<ICondicaoClimaticaService>();
            _mockMapper = new Mock<IMapper>();

            // Inicializa o controller com os serviços e mapper mockados
            _controller = new CondicaoClimaticaController(_mockCondicaoClimaticaService.Object, _mockMapper.Object);
        }

        // Método para criar e configurar um DbSet mock para CondicaoClimaticaModel
        private DbSet<CondicaoClimaticaModel> MockDbSet()
        {
            // Lista de CondicoesClimaticas para simular dados no banco de dados
            var data = new List<CondicaoClimaticaModel>
            {
                new CondicaoClimaticaModel { CondicaoClimaticaId = 1 },
                new CondicaoClimaticaModel { CondicaoClimaticaId = 2 }
            }.AsQueryable();

            // Cria o mock do DbSet
            var mockSet = new Mock<DbSet<CondicaoClimaticaModel>>();

            // Configura o comportamento do mock DbSet para simular uma consulta ao banco de dados
            mockSet.As<IQueryable<CondicaoClimaticaModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<CondicaoClimaticaModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<CondicaoClimaticaModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<CondicaoClimaticaModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            // Retorna o DbSet mock
            return mockSet.Object;
        }

        [Fact]
        public void Get_ReturnsHttpStatusCode200()
        {
            // Arrange
            var CondicoesClimaticas = new List<CondicaoClimaticaModel>
            {
                new CondicaoClimaticaModel { CondicaoClimaticaId = 1 },
                new CondicaoClimaticaModel { CondicaoClimaticaId = 2 }
            };
            var CondicaoClimaticaViewModels = CondicoesClimaticas.Select(c => new CondicaoClimaticaViewModel { CondicaoClimaticaId = c.CondicaoClimaticaId });

            var mockService = new Mock<ICondicaoClimaticaService>();
            mockService.Setup(s => s.ListarCondicoesClimaticas()).Returns(CondicoesClimaticas);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<IEnumerable<CondicaoClimaticaViewModel>>(CondicoesClimaticas)).Returns(CondicaoClimaticaViewModels);

            var controller = new CondicaoClimaticaController(mockService.Object, mockMapper.Object);

            // Act
            var result = controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result); // Confirma se o retorno é Ok
            Assert.Equal(200, okResult.StatusCode); // Confirma se o código de status é 200
        }
    }
}