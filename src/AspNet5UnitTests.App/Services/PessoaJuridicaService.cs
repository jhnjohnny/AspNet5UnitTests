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

        public PessoaJuridica BuscarIdPessoa(int idPessoa)
        {
            var result = _repositorieDbContext.PessoasJuridicas.FirstOrDefault(x => x.IdPessoa == idPessoa);

            return result;
        }

        public PessoaJuridica BuscarPessoa(PessoaJuridica pessoa)
        {
            var result = _repositorieDbContext.PessoasJuridicas.Find(pessoa.IdPessoa);

            return result;
        }

        public int CalcularIdadeIdPessoa(int idPessoa)
        {
            var dataNasc = _repositorieDbContext.PessoasJuridicas.Find(idPessoa).DataNasc;

            var idade = CalcularIdade(dataNasc);

            return idade;
        }
        private int CalcularIdade(DateTime dateTime)
        {
            return DateTime.Now.Year - dateTime.Year;
        }

        public List<PessoaJuridica> ListarPessoas()
        {
            var result = _repositorieDbContext.PessoasJuridicas.ToList();

            return result;
        }

        public Decimal SaldoIdPessoa(int idPessoa)
        {
            var result = _contaCorrenteService.SaldoIdPessoa(idPessoa);

            return result;
        }
    }
}
