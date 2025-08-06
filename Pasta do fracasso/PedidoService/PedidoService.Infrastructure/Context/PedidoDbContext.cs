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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PedidoDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
