using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5UnitTests.App.Models
{
    public class Pessoa
    {
        [Key]
        public int IdPessoa { get; set; }
        public String NomeCompleto { get; set; }
        public String Email { get; set; }
        public String Telefone { get; set; }
        public DateTime DataNasc { get; set; }
    }
}
