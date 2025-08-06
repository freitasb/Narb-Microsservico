using MediatR;
using PedidoService.Application.Repositories;
using PedidoService.Domain.Entities;

namespace PedidoService.Application.Commands.CriarPedido
{
    public class CriarPedidoCommandHandler : IRequestHandler<CriarPedidoCommand, Guid>
    {
        private readonly IPedidoRepository _pedidoRepository;

        public CriarPedidoCommandHandler(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public async Task<Guid> Handle(CriarPedidoCommand request, CancellationToken cancellationToken)
        {
            var itens = request.Itens.Select(item =>
                new PedidoItem(item.ProdutoId, item.NomeProduto, item.Quantidade, item.PrecoUnitario)).ToList();

            var pedido = new Pedido(request.ClienteId, itens);

            foreach (var item in request.Itens)
            {
                var pedidoItem = new PedidoItem(item.ProdutoId, item.NomeProduto, item.Quantidade, item.PrecoUnitario);
                pedido.AdicionarItem(pedidoItem);
            }

            await _pedidoRepository.AdicionarAsync(pedido);
             return pedido.Id;
        }
    }
}
