using AspNet5UnitTests.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNet5UnitTests.App.Interfaces
{
    public interface IPessoaService<T>  //<out R, in E>
    {
        T BuscarIdPessoa(int IdPessoa);
        T BuscarPessoa(T Pessoa);
        List<T> ListarPessoas();
        Decimal SaldoIdPessoa(int IdPessoa);
        int CalcularIdadeIdPessoa(int IdPessoa);
    }
}
