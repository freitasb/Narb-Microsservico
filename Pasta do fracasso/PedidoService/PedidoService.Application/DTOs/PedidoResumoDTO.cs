using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PedidoService.Application.DTOs
{
    public class PedidoResumoDTO
    {
        public Guid Id { get; set; }
        public DateTime DataCriacao { get; set; }
        public int TotalItens { get; set; }
        public decimal ValorTotal { get; set; }
    }
}
