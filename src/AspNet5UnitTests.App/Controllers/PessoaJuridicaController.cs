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
    public class PessoaJuridicaController : ControllerBase
    {
        private readonly IPessoaService<PessoaJuridica> _pessoaService;

        public PessoaJuridicaController(IPessoaService<PessoaJuridica> pessoaService)
        {
            _pessoaService = pessoaService;
        }


        // api/PessoaJuridica/ListarPessoas
        [HttpGet]
        [Route("ListarPessoas")]
        public IEnumerable<PessoaJuridica> ListarPessoas()
        {
            return _pessoaService.ListarPessoas();
        }

        [HttpGet]
        [Route("BuscarPessoa")]
        public PessoaJuridica BuscarPessoa(PessoaJuridica pessoa)
        {
            return _pessoaService.BuscarPessoa(pessoa);
        }

        [HttpGet]
        [Route("BuscarIdPessoa/{IdPessoa}")]
        public PessoaJuridica BuscarIdPessoa(int IdPessoa)
        {
            return _pessoaService.BuscarIdPessoa(IdPessoa);
        }

    }
}
