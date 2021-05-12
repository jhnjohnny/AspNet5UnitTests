using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNet5UnitTests.App.Controllers;
using AspNet5UnitTests.App.Interfaces;
using AspNet5UnitTests.App.Models;
using AspNet5UnitTests.App.Repositories;
using AspNet5UnitTests.App.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace AspNet5UnitTests.Tests.Controllers
{
    //[ExcludeFromCodeCoverage]
    [TestClass]
    public class PessoaFisicaControllerTest
    {
        private PessoaFisicaController _controller;
        private IPessoaService<PessoaFisica> _pessoaService;
        private readonly RepositorieDbContext _repositorieDbContext;
        private readonly Mock<IContaService<ContaCorrente>> _mockContaService;

        public PessoaFisicaControllerTest()
        {
            var fakeDbContext = new FakeDbContext();
            _repositorieDbContext = fakeDbContext.GetContext();
            _mockContaService = new Mock<IContaService<ContaCorrente>>();

            _pessoaService = new PessoaFisicaService(_repositorieDbContext, _mockContaService.Object);
        }

        [TestMethod]
        public void BuscarPessoaPorId_OK()
        {
            // Arrange
            var idPessoa = 1;

            // Act
            _controller = new PessoaFisicaController(_pessoaService);
            var result = _controller.BuscarIdPessoa(idPessoa);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(idPessoa, result.IdPessoa);
        }

        [TestMethod]
        public void RetornarSaldoPessoaPorId_OK()
        {
            // Arrange
            var idPessoa = 1;
            var saldo = 1000;
            _mockContaService.Setup(x => x.SaldoIdPessoa(idPessoa)).Returns(saldo);

            // Act
            _pessoaService = new PessoaFisicaService(_repositorieDbContext, _mockContaService.Object);
            _controller = new PessoaFisicaController(_pessoaService);
            var result = _controller.SaldoIdPessoa(idPessoa);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(saldo, result);
        }

        [TestMethod]
        public void ListarPessoas_OK()
        {
            // Arrange

            // Act
            _controller = new PessoaFisicaController(_pessoaService);
            var result = _controller.ListarPessoas();

            // Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BuscarPessoa_OK()
        {
            // Arrange
            var pessoa = new PessoaFisica()
            {
                IdPessoa = 1,
                NomeCompleto = "Teste Fulano Completo",
                CPF = "123456789",
                DataNasc = DateTime.Now,
                Email = "teste.email@email.com",
                Telefone = "99554512"
            };

            // Act
            _controller = new PessoaFisicaController(_pessoaService);
            var result = _controller.BuscarPessoa(pessoa);

            // Assert
            Assert.IsNotNull(result);
        }


    }
}
