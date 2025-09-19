using Microsoft.EntityFrameworkCore;
using PedidoService.Application.Repositories;
using PedidoService.Domain.Entities;
using PedidoService.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace PedidoService.Infrastructure.Repositories
{
    public class PedidoRepository : RepositoryBase<Pedido>, IPedidoRepository
    {
        public PedidoRepository(PedidoDbContext context) : base(context){ }

        public async Task<IEnumerable<Pedido>> BuscarPorClienteIdAsync(Guid clienteId)
        {
            return await _dbSet
                .Where(p => p.ClienteId == clienteId)
                .ToListAsync();
        }
    }
}
