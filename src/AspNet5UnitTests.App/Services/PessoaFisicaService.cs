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

        public PessoaFisicaService(RepositorieDbContext repositorieDbContext)
        {
            _repositorieDbContext = repositorieDbContext;
        }

        public PessoaFisica BuscarIdPessoa(int IdPessoa)
        {
            var result = _repositorieDbContext.PessoaFisica.FirstOrDefault(x => x.IdPessoa == IdPessoa);

            return result;
        }

        public PessoaFisica BuscarPessoa(PessoaFisica Pessoa)
        {
            var result = _repositorieDbContext.PessoaFisica.Find(Pessoa);

            return result;
        }

        public List<PessoaFisica> ListarPessoas()
        {
            var result = _repositorieDbContext.PessoaFisica.ToList();

            return result;
        }

    }
}
