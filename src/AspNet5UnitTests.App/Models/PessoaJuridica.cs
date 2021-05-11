using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5UnitTests.App.Models
{
    public class PessoaJuridica : Pessoa
    {
        public String CNPJ { get; set; }
    }
}
