using MediatR;
using PedidoService.Application.DTOs;
using PedidoService.Domain.Value_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoService.Application.Commands.AtualizarEmailDoCliente
{
    public class AtualizarEmailDoClienteCommand : IRequest<Guid>
    {
        public Guid ClienteId { get; set; }
        public Email Email { get; set; }
    }
}
