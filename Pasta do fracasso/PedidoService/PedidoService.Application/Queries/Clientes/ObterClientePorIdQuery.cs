using MediatR;
using PedidoService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoService.Application.Queries.Clientes
{
    public class ObterClientePorIdQuery : IRequest<ClienteDTO>
    {
        public Guid ClienteId { get; }
        public ObterClientePorIdQuery(Guid clienteId) => ClienteId = clienteId;
    }
}
