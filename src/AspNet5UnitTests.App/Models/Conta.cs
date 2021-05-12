using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5UnitTests.App.Models
{
    public class Conta
    {
        [Key]
        public int IdConta { get; set; }
        public int IdPessoa { get; set; }
        public String Agencia { get; set; }
        public String Numero { get; set; }
        public String Digito { get; set; }
    }
}
