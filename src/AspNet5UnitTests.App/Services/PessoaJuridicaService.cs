using AspNet5UnitTests.App.Interfaces;
using AspNet5UnitTests.App.Models;
using AspNet5UnitTests.App.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5UnitTests.App.Services
{
    public class PessoaJuridicaService : IPessoaService<PessoaJuridica>
    {
        private readonly RepositorieDbContext _repositorieDbContext;
        private readonly IContaService<ContaCorrente> _contaCorrenteService;

        public PessoaJuridicaService(RepositorieDbContext repositorieDbContext, IContaService<ContaCorrente> contaCorrenteService)
        {
            _repositorieDbContext = repositorieDbContext;
            _contaCorrenteService = contaCorrenteService;

            _repositorieDbContext.InsertDadosTest(); // Apenas para testes
        }

        public PessoaJuridica BuscarIdPessoa(int IdPessoa)
        {
            var result = _repositorieDbContext.PessoasJuridicas.FirstOrDefault(x => x.IdPessoa == IdPessoa);

            return result;
        }

        public PessoaJuridica BuscarPessoa(PessoaJuridica Pessoa)
        {
            var result = _repositorieDbContext.PessoasJuridicas.Find(Pessoa.IdPessoa);

            return result;
        }

        public List<PessoaJuridica> ListarPessoas()
        {
            var result = _repositorieDbContext.PessoasJuridicas.ToList();

            return result;
        }

        public Decimal SaldoIdPessoa(int IdPessoa)
        {
            var result = _contaCorrenteService.SaldoIdPessoa(IdPessoa);

            return result;
        }
    }
}
