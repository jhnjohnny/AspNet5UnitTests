using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5UnitTests.App.Models
{
    public class PessoaFisica : Pessoa
    {
        public String CPF { get; set; }
        public String Sexo { get; set; }
    }
}
