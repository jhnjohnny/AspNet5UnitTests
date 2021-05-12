using System;
using System.Diagnostics.CodeAnalysis;
using AspNet5UnitTests.App.Interfaces;
using AspNet5UnitTests.App.Models;
using AspNet5UnitTests.App.Repositories;
using AspNet5UnitTests.App.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AspNet5UnitTests.Tests.Services
{
    //[ExcludeFromCodeCoverage]
    [TestClass]
    public class PessoaFisicaServiceTest
    {
        private PessoaFisicaService _service;
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
            var idPessoa = 1;

            // Act
            _service = new PessoaFisicaService(_repositorieDbContext, _mockContaService.Object);
            var result = _service.BuscarIdPessoa(idPessoa);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(idPessoa,result.IdPessoa);
        }

        [TestMethod]
        public void RetornarSaldoPessoaPorId_OK()
        {
            // Arrange
            var idPessoa = 1;
            var saldo = 1000;
            _mockContaService.Setup(x => x.SaldoIdPessoa(idPessoa)).Returns(saldo);

            // Act
            _service = new PessoaFisicaService(_repositorieDbContext, _mockContaService.Object);
            var result = _service.SaldoIdPessoa(idPessoa);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(saldo,result);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void BuscarPessoaPorId_ExceptionNull()
        {
            // Arrange
            var idPessoa = 5;

            // Act
            _service = new PessoaFisicaService(_repositorieDbContext, _mockContaService.Object);
            _service.BuscarIdPessoa(idPessoa);

            // Assert
        }

        [TestMethod]
        public void RetornarIdadePessoaPorId_OK()
        {
            // Arrange
            var idPessoa = 1;

            // Act
            _service = new PessoaFisicaService(_repositorieDbContext, _mockContaService.Object);
            var result = _service.CalcularIdadeIdPessoa(idPessoa);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(25, result);
        }


    }
}
