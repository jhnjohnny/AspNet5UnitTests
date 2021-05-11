using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNet5UnitTests.App.Models;
using Microsoft.EntityFrameworkCore.Internal;

namespace AspNet5UnitTests.App.Repositories
{
    public class RepositorieDbContext : DbContext
    {
        public RepositorieDbContext(DbContextOptions<RepositorieDbContext> options) : base(options)
        {
            
        }

        public DbSet<PessoaFisica> PessoaFisica { get; set; }
        public DbSet<PessoaJuridica> PessoaJuridica { get; set; }
    }
}
