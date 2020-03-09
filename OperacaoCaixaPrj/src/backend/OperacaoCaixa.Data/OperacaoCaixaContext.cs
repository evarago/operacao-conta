 
using Microsoft.EntityFrameworkCore;
using OperacaoCaixa.Core.Models;

namespace OperacaoCaixa.Data
{
    public sealed class OperacaoCaixaContext : DbContext
    {
        public OperacaoCaixaContext(DbContextOptions options)
            : base(options)
        {
           // these are mutually exclusive, migrations cannot be used with EnsureCreated()
            Database.EnsureCreated();
           //Database.Migrate();
        }

        public DbSet<Pessoa> Pessoa { get; set; }
        public DbSet<ContaOperacao> ContaOperacao { get; set; }
        public DbSet<ContaCliente> ContaCliente { get; set; }
        public DbSet<ContaSaldo> ContaSaldo { get; set; }
        
    }
}