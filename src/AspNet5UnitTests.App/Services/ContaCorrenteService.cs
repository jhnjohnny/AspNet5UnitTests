using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet5UnitTests.App.Interfaces;
using AspNet5UnitTests.App.Models;
using AspNet5UnitTests.App.Repositories;

namespace AspNet5UnitTests.App.Services
{
    public class ContaCorrenteService : IContaService<ContaCorrente>
    {
        private readonly RepositorieDbContext _repositorieDbContext;

        public ContaCorrenteService(RepositorieDbContext repositorieDbContext)
        {
            _repositorieDbContext = repositorieDbContext;

            _repositorieDbContext.InsertDadosTest(); // Apenas para testes
        }


        public ContaCorrente BuscarIdConta(int IdConta)
        {
            var result = _repositorieDbContext.ContaCorrentes.FirstOrDefault(x => x.IdConta == IdConta);

            return result;
        }

        public ContaCorrente BuscarIdPessoa(int IdPessoa)
        {
            var result = _repositorieDbContext.ContaCorrentes.FirstOrDefault(x => x.IdPessoa == IdPessoa);

            return result;
        }

        public Decimal SaldoIdPessoa(int IdPessoa)
        {
            var result = _repositorieDbContext.ContaCorrentes.FirstOrDefault(x => x.IdPessoa == IdPessoa);

            if (result == null) return 0;

            return result.Saldo;
        }

        public ContaCorrente BuscarConta(ContaCorrente Conta)
        {
            var result = _repositorieDbContext.ContaCorrentes.Find(Conta.IdConta);

            return result;
        }

    }
}
