using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoService.Domain.Entities
{
    public class Pedido
    {
        public Guid Id { get; private set; } = Guid.NewGuid(); // Identidade do Pedido

        public Guid ClienteId { get; private set; }
        public Cliente Cliente { get; private set; } = null!;
        public DateTime DataCriacao { get; private set; }
        private readonly List<PedidoItem> _itens = new();
        public IReadOnlyCollection<PedidoItem> Itens => _itens.AsReadOnly();

        public decimal Total => _itens.Sum(i => i.PrecoTotal);

        // Construtor privado para EF ou proteção de invariantes
        private Pedido() { }

        public Pedido(Guid clienteId)
        {
            if (clienteId == Guid.Empty)
                throw new ArgumentException("ClienteId inválido.");

            Id = Guid.NewGuid();
            ClienteId = clienteId;
            DataCriacao = DateTime.UtcNow;
        }

        public void AdicionarItem(PedidoItem item)
        {
            if (item == null)
                throw new ArgumentException("Item inválido");

            _itens.Add(item);
        }
    }
}
