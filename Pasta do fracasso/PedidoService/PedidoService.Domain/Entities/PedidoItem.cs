using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoService.Domain.Entities
{
    public class PedidoItem
    {
        public Guid Id { get; private set; }
        public Guid ProdutoId { get; private set; }
        public string NomeProduto { get; private set; }
        public int Quantidade { get; private set; }
        public decimal PrecoUnitario { get; private set; }

        public decimal PrecoTotal => Quantidade * PrecoUnitario;

        public PedidoItem(Guid produtoId, string nomeProduto, int quantidade, decimal precoUnitario)
        {
            if (produtoId == Guid.Empty)
                throw new ArgumentException("ProdutoId inválido.");
            if (string.IsNullOrWhiteSpace(nomeProduto))
                throw new ArgumentException("Nome do produto é obrigatório.");
            if (quantidade <= 0)
                throw new ArgumentException("Quantidade deve ser maior que zero.");
            if (precoUnitario <= 0)
                throw new ArgumentException("Preço unitário deve ser maior que zero.");

            Id = Guid.NewGuid();
            ProdutoId = produtoId;
            NomeProduto = nomeProduto;
            Quantidade = quantidade;
            PrecoUnitario = precoUnitario;
        }

        // EF Core precisa disso para reconstruir os dados do banco
        private PedidoItem() { }
    }
}
