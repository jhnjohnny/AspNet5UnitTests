using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNet5UnitTests.App.Repositories;
using AspNet5UnitTests.App.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AspNet5UnitTests.Tests.Services
{
    //[ExcludeFromCodeCoverage]
    [TestClass]
    public class ContaCorrenteServiceTest
    {
        private ContaCorrenteService _service;
        private RepositorieDbContext _repositorieDbContext;

        [TestInitialize]
        public void Initialize()
        {
            var fakeDbContext = new FakeDbContext();
            _repositorieDbContext = fakeDbContext.GetContext();
        }

        [TestMethod]
        public void BuscarContaPorIdConta_OK()
        {
            // Arrange (Dado)
            var idConta = 1;

            // Act (Quando)
            _service = new ContaCorrenteService(_repositorieDbContext);
            var result = _service.BuscarIdConta(idConta);

            // Assert (Então)
            Assert.IsNotNull(result);
            Assert.AreEqual(idConta, result.IdPessoa);
        }

        [TestMethod]
        public void RetornarSaldoContaPorIdPessoa_OK()
        {
            // Arrange (Dado)
            var idPessoa = 1;

            // Act (Quando)
            _service = new ContaCorrenteService(_repositorieDbContext);
            var result = _service.SaldoIdPessoa(idPessoa);

            // Assert (Então)
            Assert.IsNotNull(result);
            Assert.AreEqual(2000, result);
        }

        [TestMethod]
        public void RetornarSaldoContaPorIdPessoa_Zero()
        {
            // Arrange (Dado)
            var idPessoa = -1;

            // Act (Quando)
            _service = new ContaCorrenteService(_repositorieDbContext);
            var result = _service.SaldoIdPessoa(idPessoa);

            // Assert (Então)
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result);
        }


    }
}
