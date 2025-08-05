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

        public string ClienteNome { get; private set; }
        public DateTime DataCriacao { get; private set; }
        public decimal Total { get; private set; }

        private readonly List<PedidoItem> _itens = new();
        public IReadOnlyCollection<PedidoItem> Itens => _itens.AsReadOnly();

        // Construtor privado para EF ou proteção de invariantes
        private Pedido() { }

        public Pedido(string clienteNome, List<PedidoItem> itens)
        {
            if (string.IsNullOrWhiteSpace(clienteNome))
                throw new ArgumentException("Nome do cliente é obrigatório.");

            if (itens == null || itens.Count == 0)
                throw new ArgumentException("Pedido deve conter ao menos um item.");

            ClienteNome = clienteNome;
            DataCriacao = DateTime.UtcNow;

            foreach (var item in itens)
                AdicionarItem(item);

            Total = _itens.Sum(i => i.PrecoTotal);
        }

        public void AdicionarItem(PedidoItem item)
        {
            if (item == null)
                throw new ArgumentException("Item inválido");

            _itens.Add(item);
        }
    }
}
