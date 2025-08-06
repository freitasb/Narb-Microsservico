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
    public class PedidoRepository : IPedidoRepository
    {
        private readonly PedidoDbContext _context; //Context é injetado dentro do Repository para conectar ao banco

        public PedidoRepository(PedidoDbContext context)
        {
            _context = context;
        }

        public async Task AdicionarAsync(Pedido pedido)
        {
            await _context.Pedidos.AddAsync(pedido);
            await _context.SaveChangesAsync();
        }

        public async Task<Pedido?> ObterPorIdAsync(Guid id)
        {
            return await _context.Pedidos
                .Include(p => p.Cliente)
                .Include(p => p.Itens)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public Task<List<Pedido>> ListarTodosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
