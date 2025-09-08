using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoService.Application.Commands.CriarCliente
{
    public record CriarClienteCommand(
        string Nome,
        string Email,
        string Cpf,
        string Telefone
    ) : IRequest<Guid>;
}
