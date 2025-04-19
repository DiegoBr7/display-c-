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
    public class AcidenteControllerTests
    {
        // Mocks dos serviços e do mapper
        private readonly Mock<IAcidenteService> _mockAcidenteService;
        private readonly Mock<IMapper> _mockMapper;

        // Controlador que será testado
        private readonly AcidenteController _controller;

        public AcidenteControllerTests()
        {
            // Inicializa os mocks
            _mockAcidenteService = new Mock<IAcidenteService>();
            _mockMapper = new Mock<IMapper>();

            // Inicializa o controller com os serviços e mapper mockados
            _controller = new AcidenteController(_mockAcidenteService.Object, _mockMapper.Object);
        }

        // Método para criar e configurar um DbSet mock para AcidenteModel
        private DbSet<AcidenteModel> MockDbSet()
        {
            // Lista de Acidentes para simular dados no banco de dados
            var data = new List<AcidenteModel>
            {
                new AcidenteModel { AcidenteId = 1, Localizacao = "Acidente 1", Gravidade = "Média" },
                new AcidenteModel { AcidenteId = 2, Localizacao = "Acidente 2", Gravidade = "Alta" }
            }.AsQueryable();

            // Cria o mock do DbSet
            var mockSet = new Mock<DbSet<AcidenteModel>>();

            // Configura o comportamento do mock DbSet para simular uma consulta ao banco de dados
            mockSet.As<IQueryable<AcidenteModel>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<AcidenteModel>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<AcidenteModel>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<AcidenteModel>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());

            // Retorna o DbSet mock
            return mockSet.Object;
        }

        [Fact]
        public void Get_ReturnsHttpStatusCode200()
        {
            // Arrange
            var Acidentes = new List<AcidenteModel>
            {
                new AcidenteModel { AcidenteId = 1, Localizacao = "Acidente 1", Gravidade = "Média" },
                new AcidenteModel { AcidenteId = 2, Localizacao = "Acidente 2", Gravidade = "Alta" }
            };
            var AcidenteViewModels = Acidentes.Select(c => new AcidenteViewModel { AcidenteId = c.AcidenteId, Localizacao = c.Localizacao, Gravidade = c.Gravidade });

            var mockService = new Mock<IAcidenteService>();
            mockService.Setup(s => s.ListarAcidentes()).Returns(Acidentes);

            var mockMapper = new Mock<IMapper>();
            mockMapper.Setup(m => m.Map<IEnumerable<AcidenteViewModel>>(Acidentes)).Returns(AcidenteViewModels);

            var controller = new AcidenteController(mockService.Object, mockMapper.Object);

            // Act
            var result = controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result); // Confirma se o retorno é Ok
            Assert.Equal(200, okResult.StatusCode); // Confirma se o código de status é 200
        }
    }
}