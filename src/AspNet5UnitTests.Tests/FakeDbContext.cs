using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AspNet5UnitTests.App.Models;
using AspNet5UnitTests.App.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AspNet5UnitTests.Tests
{
    [ExcludeFromCodeCoverage]
    public class FakeDbContext
    {
        private RepositorieDbContext _dbContext;

        public FakeDbContext()
        {
            var options = new DbContextOptionsBuilder<RepositorieDbContext>()
                .UseInMemoryDatabase("FakeDB")
                .Options;

            _dbContext = new RepositorieDbContext(options);

            InsertDadosTest();
        }

        public RepositorieDbContext GetContext() => _dbContext;

        public void InsertDadosTest()
        {
            if(_dbContext.Database.EnsureCreated())
            {
                _dbContext.PessoasFisicas.Add(
                    new PessoaFisica()
                    {
                        IdPessoa = 1,
                        NomeCompleto = "Teste Fulano Completo",
                        CPF = "123456789",
                        DataNasc = DateTime.Now,
                        Email = "teste.email@email.com",
                        Telefone = "99554512"
                    }
                );

                _dbContext.PessoasJuridicas.Add(
                    new PessoaJuridica()
                    {
                        IdPessoa = 2,
                        NomeEmpresa = "Empresa Teste",
                        CNPJ = "034567000180",
                        DataNasc = DateTime.Now,
                        Email = "teste.email@email.com",
                        Telefone = "2021554"
                    }
                );

                _dbContext.ContaCorrentes.Add(
                    new ContaCorrente()
                    {
                        IdConta = 1,
                        IdPessoa = 1,
                        Agencia = "500",
                        Numero = "1234",
                        Digito = "5",
                        Saldo = 2000
                    }
                );

                _dbContext.SaveChanges();
            }
        }
    }
}
