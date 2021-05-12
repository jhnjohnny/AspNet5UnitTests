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


        public ContaCorrente BuscarIdConta(int idConta)
        {
            var result = _repositorieDbContext.ContaCorrentes.FirstOrDefault(x => x.IdConta == idConta);

            return result;
        }

        public ContaCorrente BuscarIdPessoa(int idPessoa)
        {
            var result = _repositorieDbContext.ContaCorrentes.FirstOrDefault(x => x.IdPessoa == idPessoa);

            return result;
        }

        public Decimal SaldoIdPessoa(int idPessoa)
        {
            var result = _repositorieDbContext.ContaCorrentes.FirstOrDefault(x => x.IdPessoa == idPessoa);

            if (result == null) return 0;

            return result.Saldo;
        }

        public ContaCorrente BuscarConta(ContaCorrente conta)
        {
            var result = _repositorieDbContext.ContaCorrentes.Find(conta.IdConta);

            return result;
        }

    }
}
