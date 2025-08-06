using PedidoService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoService.Application.Repositories
{
    public interface IPedidoRepository
    {
        Task AdicionarAsync(Pedido pedido);
        Task<Pedido?> ObterPorIdAsync(Guid id);
        Task<List<Pedido>> ListarTodosAsync();
    }
}
