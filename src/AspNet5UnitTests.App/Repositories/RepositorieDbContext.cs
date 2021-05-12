using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;
using AspNet5UnitTests.App.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace AspNet5UnitTests.App.Repositories
{
    [ExcludeFromCodeCoverage]
    public class RepositorieDbContext : DbContext
    {
        public RepositorieDbContext(DbContextOptions<RepositorieDbContext> options) : base(options)
        {

        }


        public DbSet<PessoaFisica> PessoasFisicas { get; set; }
        public DbSet<PessoaJuridica> PessoasJuridicas { get; set; }
        public DbSet<ContaCorrente> ContaCorrentes { get; set; }


        public void InsertDadosTest()
        {
            if (this.Database.EnsureCreated())
            {
                this.PessoasFisicas.Add(
                    new PessoaFisica()
                    {
                        IdPessoa = 1,
                        NomeCompleto = "Fulano Completo",
                        CPF = "123456789",
                        DataNasc = DateTime.Now.AddYears(-25),
                        Email = "email@email.com",
                        Telefone = "99554512"
                    }
                );

                this.PessoasJuridicas.Add(
                    new PessoaJuridica()
                    {
                        IdPessoa = 2,
                        NomeEmpresa = "Empresa Fulano",
                        CNPJ = "034567000180",
                        DataNasc = DateTime.Now.AddYears(-10),
                        Email = "email@email.com",
                        Telefone = "2021554"
                    }
                );

                this.ContaCorrentes.Add(
                    new ContaCorrente()
                    {
                        IdConta = 1,
                        IdPessoa = 1,
                        Agencia = "500",
                        Numero = "1234",
                        Digito = "5",
                        Saldo = 2000
                    }
                );

                this.SaveChanges();
            }
        }

    }
}
