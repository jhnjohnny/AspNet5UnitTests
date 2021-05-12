using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNet5UnitTests.App.Interfaces;
using AspNet5UnitTests.App.Models;
using AspNet5UnitTests.App.Repositories;
using AspNet5UnitTests.App.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AspNet5UnitTests.Tests.Services
{
    //[ExcludeFromCodeCoverage]
    [TestClass]
    public class PessoaJuridicaServiceTest
    {
        private PessoaJuridicaService _service;
        private RepositorieDbContext _repositorieDbContext;
        private Mock<IContaService<ContaCorrente>> _mockContaService;

        [TestInitialize]
        public void Initialize()
        {
            var fakeDbContext = new FakeDbContext();
            _repositorieDbContext = fakeDbContext.GetContext();

            _mockContaService = new Mock<IContaService<ContaCorrente>>();
        }

        [TestMethod]
        public void BuscarPessoaPorId_OK()
        {
            // Arrange
            var idPessoa = 2;

            // Act
            _service = new PessoaJuridicaService(_repositorieDbContext, _mockContaService.Object);
            var result = _service.BuscarIdPessoa(idPessoa);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(idPessoa, result.IdPessoa);
        }
    }
}
