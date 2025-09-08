using MediatR;
using PedidoService.Application.Interfaces;
using PedidoService.Application.Repositories;
using PedidoService.Domain.Entities;

namespace PedidoService.Application.Commands.CriarPedido
{
    public class CriarPedidoCommandHandler : IRequestHandler<CriarPedidoCommand, Guid>
    {
        private readonly IRepository<Pedido> _repository;

        public CriarPedidoCommandHandler(IRepository<Pedido> pedidoRepository)
        {
            _repository = pedidoRepository;
        }

        public async Task<Guid> Handle(CriarPedidoCommand request, CancellationToken cancellationToken)
        {
            var pedido = new Pedido(request.ClienteId);

            foreach (var itemDto in request.Itens)
            {
                var item = new PedidoItem(itemDto.ProdutoId, itemDto.NomeProduto, itemDto.Quantidade, itemDto.PrecoUnitario);
                pedido.AdicionarItem(item);
            }

            await _repository.AddAsync(pedido);
            return pedido.Id;
        }

    }
}
