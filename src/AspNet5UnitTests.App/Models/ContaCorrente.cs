using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5UnitTests.App.Models
{
    public class ContaCorrente : Conta
    {
        public Decimal Saldo { get; set; }

        //public Decimal ChequeEspecial { get; set; }
    }
}
