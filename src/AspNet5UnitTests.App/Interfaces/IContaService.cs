using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet5UnitTests.App.Models;

namespace AspNet5UnitTests.App.Interfaces
{
    public interface IContaService<T>
    {
        T BuscarIdConta(int IdConta);

        T BuscarIdPessoa(int IdPessoa);

        Decimal SaldoIdPessoa(int IdPessoa);

        T BuscarConta(T Conta);
    }
}
