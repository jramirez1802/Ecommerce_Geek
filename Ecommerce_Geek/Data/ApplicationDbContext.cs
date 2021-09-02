using Ecommerce_Geek.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;

namespace Ecommerce_Geek.Data
{
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>();
            builder.Entity<ApplicationUser>()
                .HasMany(t => t.Pedidos)
                .WithOne(t => t.Usuario);

            builder.Entity<Produto>().HasKey(t => t.Id);
            builder.Entity<Produto>().Property(t => t.Id).ValueGeneratedOnAdd();

            builder.Entity<Produto>().HasOne(t => t.Detalhe)
                .WithOne(t => t.Produto)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Produto>().HasOne(t => t.Categoria)
                .WithMany(t => t.Produtos)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<Produto>().HasMany(t => t.Avaliacoes)
                .WithOne(t => t.Produto)
                .HasForeignKey(t => t.ProdutoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<Detalhe>().HasKey(t => t.Id);
            builder.Entity<Detalhe>().Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Entity<Detalhe>().HasMany(t => t.Imagens)
                .WithOne(t => t.Detalhe)
                .OnDelete(DeleteBehavior.Cascade);
            
            builder.Entity<ImagemProdutos>().HasKey(t => t.Id);
            builder.Entity<ImagemProdutos>().Property(t => t.Id).ValueGeneratedOnAdd();

            builder.Entity<Categoria>().HasKey(t => t.Id);
            builder.Entity<Categoria>().Property(t => t.Id).ValueGeneratedOnAdd();

            builder.Entity<Pedido>().HasKey(t => t.Id);
            builder.Entity<Pedido>().Property(t => t.Id).ValueGeneratedOnAdd();
            builder.Entity<Pedido>().HasMany(t => t.Produtos)
                .WithMany(t => t.Pedidos);
            builder.Entity<Pedido>().HasOne(t => t.InformacoesPagamento);

            builder.Entity<InformacoesPagamento>().HasKey(t => t.Id);
            builder.Entity<InformacoesPagamento>().Property(t => t.Id).ValueGeneratedOnAdd();

        }

        public DbSet<Ecommerce_Geek.Models.AvaliacaoProduto> AvaliacaoProduto { get; set; }

        public DbSet<Ecommerce_Geek.Models.Categoria> Categoria { get; set; }

        public DbSet<Ecommerce_Geek.Models.Detalhe> Detalhe { get; set; }

        public DbSet<Ecommerce_Geek.Models.ImagemProdutos> ImagemProdutos { get; set; }

        public DbSet<Ecommerce_Geek.Models.InformacoesPagamento> InformacoesPagamento { get; set; }

        public DbSet<Ecommerce_Geek.Models.Produto> Produto { get; set; }
    }
}
