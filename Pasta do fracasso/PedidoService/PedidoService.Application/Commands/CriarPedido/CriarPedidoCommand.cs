using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using PedidoService.Application.DTOs;

namespace PedidoService.Application.Commands.CriarPedido
{
    public class CriarPedidoCommand : IRequest<Guid>
    {
        public Guid ClienteId { get; set; }
        public List<CriarPedidoItemDto> Itens { get; set; } = new();
    }
}
