using MediatR;
using PedidoService.Application.Commands.CriarPedido;
using PedidoService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoService.Application.Commands.AtualizarEmailDoCliente
{
    public class AtualizarEmailDoClienteCommandHandler : IRequestHandler<AtualizarEmailDoClienteCommand, Guid>
    {
        //private readonly IClienteRepository _clienteRepository;

        public AtualizarEmailDoClienteCommandHandler()
        {
            
        }

        public Task<Guid> Handle(AtualizarEmailDoClienteCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        //public Task<Guid> Handle(CriarPedidoCommand request, CancellationToken cancellationToken)
        //{
        //    var pedido = new Pedido(request.ClienteId);
        //
        //    foreach (var item in request.Itens)
        //    {
        //        var pedidoItem = new PedidoItem(item.ProdutoId, item.NomeProduto, item.Quantidade, item.PrecoUnitario);
        //        pedido.AdicionarItem(pedidoItem);
        //    }
        //
        //    await _pedidoRepository.AdicionarAsync(pedido);
        //    return pedido.Id;
        //}
    }
}
