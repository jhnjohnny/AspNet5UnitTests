using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet5UnitTests.App.Interfaces;
using AspNet5UnitTests.App.Models;

namespace AspNet5UnitTests.App.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaFisicaController : ControllerBase
    {
        private readonly IPessoaService<PessoaFisica> _pessoaService;

        public PessoaFisicaController(IPessoaService<PessoaFisica> pessoaService)
        {
            _pessoaService = pessoaService;
        }


        // api/PessoaFisica/ListarPessoas
        [HttpGet]
        [Route("ListarPessoas")]
        public IEnumerable<PessoaFisica> ListarPessoas()
        {
            return _pessoaService.ListarPessoas();
        }

        [HttpGet]
        [Route("BuscarPessoa")]
        public PessoaFisica BuscarPessoa(PessoaFisica pessoa)
        {
            return _pessoaService.BuscarPessoa(pessoa);
        }

        [HttpGet]
        [Route("BuscarIdPessoa/{IdPessoa}")]
        public PessoaFisica BuscarIdPessoa(int idPessoa)
        {
            return _pessoaService.BuscarIdPessoa(idPessoa);
        }

        [HttpGet]
        [Route("SaldoIdPessoa/{IdPessoa}")]
        public Decimal SaldoIdPessoa(int idPessoa)
        {
            return _pessoaService.SaldoIdPessoa(idPessoa);
        }

        [HttpGet]
        [Route("IdadeIdPessoa/{IdPessoa}")]
        public int IdadeIdPessoa(int idPessoa)
        {
            return _pessoaService.CalcularIdadeIdPessoa(idPessoa);
        }

    }
}
