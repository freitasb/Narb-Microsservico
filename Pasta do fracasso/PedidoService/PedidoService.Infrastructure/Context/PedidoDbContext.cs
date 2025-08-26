using Microsoft.EntityFrameworkCore;
using PedidoService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoService.Infrastructure.Context
{
    public class PedidoDbContext : DbContext
    {
        public PedidoDbContext(DbContextOptions<PedidoDbContext> options)
        : base(options){ }

        public DbSet<Pedido> Pedidos => Set<Pedido>();
        public DbSet<Cliente> Clientes => Set<Cliente>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(builder =>
            {
                builder.HasKey(c => c.Id);

                builder.Property(c => c.Nome)
                    .HasMaxLength(200)
                    .IsRequired();

                builder.OwnsOne(c => c.Telefone, telefone =>
                {
                    telefone.Property(t => t.Numero)
                        .HasColumnName("Telefone")
                        .HasMaxLength(11)
                        .IsRequired();
                });

                builder.OwnsOne(c => c.Email, email =>
                {
                    email.Property(e => e.Endereco)
                        .HasColumnName("Email")
                        .HasMaxLength(200)
                        .IsRequired();
                });

                builder.OwnsOne(c => c.Cpf, cpf =>
                {
                    cpf.Property(e => e.Numero)
                        .HasColumnName("Cpf")
                        .HasMaxLength(11)
                        .IsRequired();
                });
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
