using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;

namespace ProjetoFinal.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Tabelas configuradas com pluralização consistente
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<Fornecedor> Fornecedores { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração de Produto
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasOne(p => p.Categoria)
                     .WithMany(c => c.Produtos)
                     .HasForeignKey(p => p.CategoriaId)
                     .OnDelete(DeleteBehavior.Restrict); // Evita cascade delete

                entity.Property(p => p.Preco)
                     .HasColumnType("decimal(18,2)");
            });

            // Configuração de Pedido
            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasOne(p => p.Cliente)
                     .WithMany(c => c.Pedidos)
                     .HasForeignKey(p => p.ClienteId);

                entity.Property(p => p.Total)
                     .HasColumnType("decimal(18,2)");
            });

            // Configuração de Comentário
            modelBuilder.Entity<Comentario>(entity =>
            {
                entity.HasOne(c => c.BlogPost)
                     .WithMany(b => b.Comentarios)
                     .HasForeignKey(c => c.BlogPostId)
                     .OnDelete(DeleteBehavior.Cascade);
            });

            // Configurações globais
            modelBuilder.Entity<Funcionario>()
                .Property(f => f.Salario)
                .HasColumnType("decimal(18,2)");

            // Configuração de índices para melhor performance
            modelBuilder.Entity<Cliente>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Fornecedor>()
                .HasIndex(f => f.Cnpj)
                .IsUnique();
        }
    }
}