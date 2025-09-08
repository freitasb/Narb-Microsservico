using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoService.Application.DTOs
{
    public class PedidoDTO
    {
        public Guid Id { get; set; }
        public Guid ClienteId { get; set; }
        public DateTime DataCriacao { get; set; }
        public List<CriarPedidoItemDto> Itens { get; set; } = new();
    }
}
