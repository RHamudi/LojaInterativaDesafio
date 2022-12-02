using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaInterativa.Data.Mappings;
using LojaInterativa.Models;
using Microsoft.EntityFrameworkCore;

namespace LojaInterativa.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Fabricante> Fabricantes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=localhost\\sqlexpress;database=TestandoLoja;trusted_connection=true;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new FabricanteMap());
            modelBuilder.ApplyConfiguration(new ProdutosMap());
        }

    }
}