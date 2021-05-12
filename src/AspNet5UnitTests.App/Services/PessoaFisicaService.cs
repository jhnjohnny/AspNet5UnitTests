using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet5UnitTests.App.Interfaces;
using AspNet5UnitTests.App.Models;
using AspNet5UnitTests.App.Repositories;

namespace AspNet5UnitTests.App.Services
{
    public class PessoaFisicaService : IPessoaService<PessoaFisica>
    {
        private readonly RepositorieDbContext _repositorieDbContext;
        private readonly IContaService<ContaCorrente> _contaCorrenteService;

        public PessoaFisicaService(RepositorieDbContext repositorieDbContext, IContaService<ContaCorrente> contaCorrenteService)
        {
            _repositorieDbContext = repositorieDbContext;
            _contaCorrenteService = contaCorrenteService;

            _repositorieDbContext.InsertDadosTest(); // Apenas para testes
        }

        public PessoaFisica BuscarIdPessoa(int IdPessoa)
        {
            var result = _repositorieDbContext.PessoasFisicas.FirstOrDefault(x => x.IdPessoa == IdPessoa);

            if (result == null) throw new Exception();

            return result;
        }

        public PessoaFisica BuscarPessoa(PessoaFisica Pessoa)
        {
            var result = _repositorieDbContext.PessoasFisicas.Find(Pessoa.IdPessoa);

            return result;
        }

        public List<PessoaFisica> ListarPessoas()
        {
            var result = _repositorieDbContext.PessoasFisicas.ToList();

            return result;
        }

        public Decimal SaldoIdPessoa(int IdPessoa)
        {
            var result = _contaCorrenteService.SaldoIdPessoa(IdPessoa);

            return result;
        }

    }
}
