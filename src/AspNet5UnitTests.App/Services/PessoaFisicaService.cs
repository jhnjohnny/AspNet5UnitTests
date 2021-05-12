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

        public PessoaFisica BuscarIdPessoa(int idPessoa)
        {
            var result = _repositorieDbContext.PessoasFisicas.FirstOrDefault(x => x.IdPessoa == idPessoa);

            if (result == null) throw new Exception();

            return result;
        }

        public PessoaFisica BuscarPessoa(PessoaFisica pessoa)
        {
            var result = _repositorieDbContext.PessoasFisicas.Find(pessoa.IdPessoa);

            return result;
        }

        public int CalcularIdadeIdPessoa(int idPessoa)
        {
            var dataNasc = _repositorieDbContext.PessoasFisicas.Find(idPessoa).DataNasc;

            var idade = CalcularIdade(dataNasc);

            return idade;
        }
        private int CalcularIdade(DateTime dateTime)
        {
            return DateTime.Now.Year - dateTime.Year;
        }

        public List<PessoaFisica> ListarPessoas()
        {
            var result = _repositorieDbContext.PessoasFisicas.ToList();

            return result;
        }

        public Decimal SaldoIdPessoa(int idPessoa)
        {
            var result = _contaCorrenteService.SaldoIdPessoa(idPessoa);

            return result;
        }

    }
}
